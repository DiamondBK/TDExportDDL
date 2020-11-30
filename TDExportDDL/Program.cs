using System;
using System.Collections.Generic;
using Teradata.Client.Provider;
using System.Linq;

namespace TDExportDDL
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("App started");
                List<TDObject> tdobjects = new List<TDObject>();
                List<string> inserted = new List<string>();
                
                
                // App settings
                string 
                    fileLocation = AppDomain.CurrentDomain.BaseDirectory + MainSettings.Default.FileName,
                    dataSource = MainSettings.Default.DataSource,
                    userId = MainSettings.Default.Login,
                    password = MainSettings.Default.Password,
                    authenticationMechanism = MainSettings.Default.AuthenticationMechanism,
                    sessionCharacterSet = MainSettings.Default.Encoding,
                    commandText = MainSettings.Default.SelectObjSQL;
                int connTimeout = MainSettings.Default.ConnTimeout;
                

                TdConnectionStringBuilder blr = new TdConnectionStringBuilder
                {
                    DataSource = dataSource,
                    UserId = userId,
                    Password = password,
                    AuthenticationMechanism = authenticationMechanism,
                    SessionCharacterSet = sessionCharacterSet
                };

                using (TdConnection cn = new TdConnection(blr.ToString()))
                {
                    cn.Open();
                    Console.WriteLine("Connection successfull");
                    TdCommand cmd = cn.CreateCommand();
                    cmd.CommandTimeout = connTimeout;
                    cmd.CommandText = commandText;

                    try
                    {
                        using (TdDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tdobjects.Add(
                                    new TDObject
                                    {
                                        Database = reader.GetString(0).Trim()
                                        ,
                                        Name = reader.GetString(1).Trim()
                                        ,
                                        TDType = reader.GetString(2).Trim()
                                        ,
                                        Body = ""
                                        ,
                                        SnapshotDate = DateTime.Now
                                    }
                                );
                            };
                            reader.Close();
                        };
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine("-----------------------");
                        Console.WriteLine(cmd.CommandText);
                        Console.Title = "ERROR";
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ReadKey();
                    };

                    int nfetch=0;
                    tdobjects.ForEach(td =>
                    {
                        Console.WriteLine(td.Database + "." + td.Name);
                        Console.Title = $"Fetch {nfetch++} from {tdobjects.Count}";

                        switch (td.TDType)
                        {
                            case "P":
                                cmd.CommandText = $"SHOW PROCEDURE {td.Database}.{td.Name}";
                                break;
                            case "V":
                                cmd.CommandText = $"SHOW VIEW {td.Database}.{td.Name}";
                                break;
                            case "F":
                                cmd.CommandText = $"SHOW FUNCTION {td.Database}.{td.Name}";
                                break;
                            case "T":
                            case "O":
                                cmd.CommandText = $"SHOW TABLE {td.Database}.{td.Name}";
                                break;
                        };
                        try
                        {
                            using (TdDataReader readerBody = cmd.ExecuteReader())
                            {
                                int ColumnCount = readerBody.FieldCount;
                                string ListOfColumns = string.Empty;

                                td.SnapshotDate = DateTime.Now;

                                while (readerBody.Read())
                                {
                                    for (int j = 0; j <= ColumnCount - 1; j++)
                                    {
                                        ListOfColumns += readerBody[j].ToString();
                                    }
                                    ListOfColumns += Environment.NewLine;
                                };

                                string[] res = ListOfColumns.Split(new[] { "\r\n", "\r", "\n", System.Environment.NewLine }, StringSplitOptions.None);

                                string prcStr = string.Empty;

                                for (int n = 0; n < res.Length; n++)
                                {
                                    if (res[n].Contains("PROCEDURE") && n < 3)
                                    {
                                        prcStr += res[n] + res[n + 1] + Environment.NewLine;
                                        n++;
                                    }
                                    else
                                    {
                                        prcStr += res[n] + Environment.NewLine;
                                    };

                                    td.Body = prcStr.TrimEnd().EndsWith(";") ? prcStr : prcStr + ";";
                                };
                            };
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            Console.WriteLine("-----------------------");
                            Console.Title = "ERROR";
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine(cmd.CommandText);
                            Console.ReadKey();
                        };

                    }
                    );
                    Console.Title = $"Fetched {tdobjects.Count}";
                    Console.WriteLine("Write Export File");
                    System.IO.File.WriteAllLines(fileLocation, tdobjects.Select(txt => txt.Body).ToArray());

                };
                Console.WriteLine($"Export file: {fileLocation}");
                Console.WriteLine("End. Press any key to exit...");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Title = "ERROR";
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ReadKey();
            }
        }
    }
}
