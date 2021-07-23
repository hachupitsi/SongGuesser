using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

namespace SongGuesser
{
    static class Challenge
    {
        static public List<string> songs = new List<string>();
        static public int gameDuration = 60;
        static public int songDuration = 10;
        static public string savedFolder = "";
        static public bool randomStart = false;
        static public bool allDir = false;
        static string gameKey = "SOFTWARE//ChillCompany//SongGuesser";

        static public void ReadSongs()
        {
            songs.Clear();
            songs.AddRange(Directory.GetFiles(savedFolder, "*.wav", allDir ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));
        }

        static public void WriteParams()
        {
            RegistryKey rk = null;
            try
            {
                rk = Registry.CurrentUser.CreateSubKey(gameKey);
                if (rk == null)
                    return;
                rk.SetValue("GameDuration", gameDuration);
                rk.SetValue("SongDuration", songDuration);
                rk.SetValue("SavedFolder", savedFolder);
                rk.SetValue("RandomStart", randomStart);
                rk.SetValue("AllDir", allDir);
            }
            finally
            {
                if (rk != null)
                    rk.Close();
            }
        }

        static public void ReadParams()
        {
            RegistryKey rk = null;
            try
            {
                rk = Registry.CurrentUser.OpenSubKey(gameKey);
                if (rk != null)
                {
                    gameDuration = (int) rk.GetValue("GameDuration");
                    songDuration = (int)rk.GetValue("SongDuration");
                    savedFolder = (string)rk.GetValue("SavedFolder");
                    randomStart = Convert.ToBoolean(rk.GetValue("RandomStart", false));
                    allDir = Convert.ToBoolean(rk.GetValue("AllDir", false));
                }
            }
            finally
            {
                if (rk != null)
                    rk.Close();
            }
        }
    }
}
