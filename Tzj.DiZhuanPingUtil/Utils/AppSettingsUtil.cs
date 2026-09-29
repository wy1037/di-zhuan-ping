using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Tzj.DiZhuanPingUtil
{
    /// <summary>配置文件读写：保存时先读后合并，避免冲掉非界面字段。</summary>
    public static class AppSettingsUtil
    {
        private static readonly JsonSerializerSettings SerializerSettings =
            new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Include
            };

        /// <summary>默认配置文件路径（程序目录下 appsettings.json）。</summary>
        public static string ConfigFilePath
        {
            get
            {
                return Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "appsettings.json");
            }
        }

        /// <summary>文件不存在返回 null；存在则反序列化。</summary>
        public static AppSettings LoadOrNull(string path = null)
        {
            string filePath = string.IsNullOrEmpty(path) ? ConfigFilePath : path;
            if (!File.Exists(filePath))
                return null;

            string json = File.ReadAllText(filePath, Encoding.UTF8);
            if (string.IsNullOrWhiteSpace(json))
                return new AppSettings();

            return JsonConvert.DeserializeObject<AppSettings>(json, SerializerSettings)
                   ?? new AppSettings();
        }

        /// <summary>文件不存在则返回带默认值的新实例。</summary>
        public static AppSettings LoadOrDefault(string path = null)
        {
            return LoadOrNull(path) ?? new AppSettings();
        }

        /// <summary>
        /// 先读取已有配置，再用界面参数赋值后写回，
        /// 保留文件中已有、界面未绑定的字段（含手工扩展字段）。
        /// </summary>
        public static void SaveMerged(AppSettings uiValues, string path = null)
        {
            if (uiValues == null)
                throw new ArgumentNullException("uiValues");

            string filePath = string.IsNullOrEmpty(path) ? ConfigFilePath : path;
            AppSettings existing = LoadOrDefault(filePath);
            existing.ApplyUiValues(uiValues);
            WriteFile(existing, filePath);
        }

        /// <summary>仅更新注册码，其它配置字段保持不变。</summary>
        public static void SaveRegCode(string regCode, string path = null)
        {
            string filePath = string.IsNullOrEmpty(path) ? ConfigFilePath : path;
            AppSettings existing = LoadOrDefault(filePath);
            existing.RegCode = regCode ?? string.Empty;
            WriteFile(existing, filePath);
        }

        private static void WriteFile(AppSettings settings, string filePath)
        {
            string directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            string json = JsonConvert.SerializeObject(settings, SerializerSettings);
            string tempPath = filePath + ".tmp";
            File.WriteAllText(tempPath, json, new UTF8Encoding(false));
            if (File.Exists(filePath))
                File.Delete(filePath);
            File.Move(tempPath, filePath);
        }
    }
}
