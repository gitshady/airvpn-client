﻿// <airvpn_source_header>
// This file is part of AirVPN Client software.
// Copyright (C)2014-2014 AirVPN (support@airvpn.org) / https://airvpn.org )
//
// AirVPN Client is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// AirVPN Client is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with AirVPN Client. If not, see <http://www.gnu.org/licenses/>.
// </airvpn_source_header>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace AirVPN.Core
{
    public class Utils
    {

		public static string GetTempPath()
        {
            return Path.GetTempPath();
        }

        public static string GetTempFileName(bool full)
        {
			string hash = Guid.NewGuid().ToString();
			string path = hash + ".tmp";
            if (full)
                path = GetTempPath() + path;
            return path;            
        }

		public static string GetRandomToken()
		{
			Random random = new Random((int)DateTime.Now.Ticks);
			StringBuilder builder = new StringBuilder();
			char ch;
			for (int i = 0; i < 32; i++)
			{
				ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
				builder.Append(ch);
			}

			return builder.ToString();
		}

		public static string GetNameFromPath(string path)
        {
            return new FileInfo(path).Name;
        }

		public static XmlElement XmlGetFirstElementByTagName(XmlElement node, string name)
		{
			XmlNodeList list = node.GetElementsByTagName(name);
			if (list.Count == 0)
				return null;
			else
				return list[0] as XmlElement;
		}

        public static string XmlGetAttributeString(XmlNode node, string name, string def)
        {
            XmlNode nodeAttr = node.Attributes[name];
            if (nodeAttr == null)
                return def;
            else
                return nodeAttr.Value;
        }

		public static string[] XmlGetAttributeStringArray(XmlNode node, string name)
		{
			XmlNode nodeAttr = node.Attributes[name];
			if (nodeAttr == null)
				return new string[0];
			else if(nodeAttr.Value == "") // New in 2.8
				return new string[0];
			else
				return nodeAttr.Value.Split(',');
		}

		public static bool XmlGetAttributeBool(XmlNode node, string name, bool def)
		{
			XmlNode nodeAttr = node.Attributes[name];
			if (nodeAttr == null)
				return def;
			else
				return Conversions.ToBool(nodeAttr.Value);
		}

		public static Int64 XmlGetAttributeInt64(XmlNode node, string name, Int64 def)
		{
			XmlNode nodeAttr = node.Attributes[name];
			if (nodeAttr == null)
				return def;
			else
				return Conversions.ToInt64(nodeAttr.Value);
		}

		public static void XmlSetAttributeString(XmlElement node, string name, string val)
		{
			node.SetAttribute(name, val);
		}

		public static void XmlSetAttributeStringArray(XmlElement node, string name, string[] val)
		{
			if ((val == null) || (val.Length == 0)) // Added in 2.8
				node.SetAttribute(name, "");
			else
				node.SetAttribute(name, String.Join(",", val)); // TODO: Escaping
		}

		public static void XmlSetAttributeBool(XmlElement node, string name, bool val)
		{
			node.SetAttribute(name, Conversions.ToString(val));			
		}

		public static void XmlSetAttributeInt64(XmlElement node, string name, Int64 val)
		{
			node.SetAttribute(name, Conversions.ToString(val));
		}
		
		public static string UrlEncode(string url)
		{
			//return HttpUtility.UrlEncode(url); // Require System.Web
			return Uri.EscapeUriString(url);
		}

		public static int UnixTimeStamp()
		{
			return Conversions.ToUnixTime(DateTime.UtcNow);
		}

        public static bool IsIP(string IP)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(IP, @"\b((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$\b");
        }

		public static string StringCleanSpace(string v)
        {
            for (; ; )
            {
				string orig = v;

                v = v.Replace("  ", " ");
                v = v.Replace("\t\t", "\t");
                v = v.Trim();

                if (v == orig)
                    break;
            }

            return v;
        }

		public static string FormatTime(Int64 unix)
		{
			if (unix == 0)
				return "-";

			string o = "";
			Int64 now = UnixTimeStamp();
			if (unix == now)
				o = Messages.TimeJustNow;
			else if (unix < now)
				o = FormatSeconds(now - unix) + " " + Messages.TimeAgo;
			else
				o = FormatSeconds(unix - now) + " " + Messages.TimeRemain;
			return o;
		}

		public static string FormatSeconds(Int64 v)
		{
			TimeSpan ts = new TimeSpan(0, 0, (int) v);
			string o = "";

			if (ts.Days > 1)
				o += ts.Days + " days,";
			else if (ts.Days == 1)
				o += "1 day,";

			if (ts.Hours > 1)
				o += ts.Hours + " hours,";
			else if (ts.Hours == 1)
				o += "1 hour,";

			if (ts.Minutes > 1)
				o += ts.Minutes + " minutes,";
			else if (ts.Minutes == 1)
				o += "1 minute,";

			if (ts.Seconds > 1)
				o += ts.Seconds + " seconds,";
			else if (ts.Seconds == 1)
				o += "1 second,";

			return o.Trim(',');
		}

        public static string FormatBytes(Int64 bytes, bool speedSec, bool showBytes)
        {
            Int64 number = 0;
			string unit = "";
            FormatBytesEx(bytes, ref number, ref unit);

			string output = number.ToString() + " " + unit;
            if(speedSec)
                output += "/s";
            if( (showBytes) && (bytes>=0) )
            {
                output += " (" + bytes.ToString() + " bytes";
                if(speedSec)
                    output += "/s";
                output += ")";
            }
            return output;            
        }

		public static void FormatBytesEx(Int64 bytes, ref Int64 number, ref string unit)
        {
            if (bytes <= 0)
            {
                number = 0;
                unit = "B";
            }
            else
            {
                string[] suf = { "B", "KB", "MB", "GB", "TB", "PB" };
				int place = Conversions.ToInt32(Math.Floor(Math.Log(bytes, 1000)));
                double num = Math.Round(bytes / Math.Pow(1000, place), 1);
				number = Conversions.ToInt64(num);
                unit = suf[place];
            }
        }

		public static string FormatBytesEx2(long v, bool bit)
		{
			float v2 = v;
			string unit = "";

			if (bit)
				unit = "bit";
			else
				unit = "bytes";

			if (v2 >= 1000)
			{
				v2 /= 1000;
				if (bit)
					unit = "kbit";
				else
					unit = "kBytes";
			}

			if (v2 >= 1000)
			{
				v2 /= 1000;
				if (bit)
					unit = "Mbit";
				else
					unit = "MBytes";
			}

			if (v2 >= 1000)
			{
				v2 /= 1000;
				if (bit)
					unit = "Gbit";
				else
					unit = "GBytes";
			}

			if (v2 >= 1000)
			{
				v2 /= 1000;
				if (bit)
					unit = "Tbit";
				else
					unit = "TBytes";
			}

			return Math.Round(v2, 2).ToString() + " " + unit;
		}

        public static int CompareVersions(string v1, string v2)
        {
            char[] splitTokens = new char[] { '.', ',' };
            string[] tokens1 = v1.Split(splitTokens, StringSplitOptions.RemoveEmptyEntries);
            string[] tokens2 = v2.Split(splitTokens, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < Math.Max(tokens1.Length, tokens2.Length); i++)
            {
                int t1 = 0;
                int t2 = 0;
                if (i < tokens1.Length)
                {
                    try
                    {
                        if (Int32.TryParse(tokens1[i], out t1) == false)
                            t1 = 0;                        
                    }
                    finally
                    {
                    }
                }
                if (i < tokens2.Length)
                {
                    try
                    {
                        if (Int32.TryParse(tokens2[i], out t2) == false)
                            t2 = 0;
                    }
                    finally
                    {
                    }
                }

                if (t1 < t2) return -1;
                if (t1 > t2) return 1;
            }

            return 0;
        }

        public static bool HasAccessToWrite(string path)
        {
            try
            {                
                DirectoryInfo di = new DirectoryInfo(path);
                if (di.Exists == false)
                    di.Create();

				string tempPath = path + Platform.Instance.DirSep + "test.tmp";
                
                using (FileStream fs = File.Create(tempPath, 1, FileOptions.DeleteOnClose))
                {
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

		public static string SafeString(string value)
		{
			Regex rgx = new Regex("[^a-zA-Z0-9 -_]");
			value = rgx.Replace(value, "");
			return value;
		}
        
        public static bool SaveFile(string path, string content)
        {
			if (File.Exists(path))
			{
				if (File.ReadAllText(path) == content)
					return false;
			}

            TextWriter tw = new StreamWriter(path);
            tw.Write(content);
            tw.Close();

			return true;
        }

    }
}

