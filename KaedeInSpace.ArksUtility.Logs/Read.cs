using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using System.Threading;
//using System.Globalization;

namespace KaedeInSpace.ArksUtility.Logs
{
    /// <summary>
    /// PSO2ログファイルの内容を読み取ります
    /// Class for reading pso2 log files
    /// </summary>
    public class Read
    {
        private static string UserPath =>
            Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.Personal)).FullName;

        public string Path => UserPath + Properties.Resources.LogPath;

        /// <summary>
        /// 
        /// </summary>
		internal string LatestFileName(string logName)
        {
            FileInfo result = null;
            var fullLogPath = new DirectoryInfo(Path);
            var list = fullLogPath.GetFiles(logName);
            if (list.Any()) result = list.OrderByDescending(f => f.LastWriteTime).First();

            if (result == null)
                throw new FileNotFoundException(Properties.Language.NoLogFileFound);
            return result.FullName;
        }

		/// <summary>
		/// <jp>ログファイルデータ分割</jp>
		/// <en>Split log file data</en>
		/// </summary>
		public static List<string> TextSplitter(string text, string delimiter = "\t")
        {
            return text.Split(delimiter.ToCharArray()).ToList();
        }
	}
}
