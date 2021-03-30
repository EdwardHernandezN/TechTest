using System;
using System.Collections.Generic;

namespace TechTest.Commons.Utils
{
    public static class ConfigurationManager
    {
        /// <summary>
        /// Lista de propiedades 
        /// </summary>
        public static Dictionary<string, string> appSettingList { get; set; }
        /// <summary>
        /// Conexión de Base de datos
        /// </summary>
        public static readonly string _defaultConnection = "ConnectionStrings:DefaultConnection";
        
        /// <summary>
        /// Retorna Item de Variables de Entorno
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string getItem(string index)
        {
            return appSettingList[index];
        }
    }
}
