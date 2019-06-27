using System;
using System.IO;
using System.Reflection;

namespace ExistingSQLite.BLL
{
    public class ResourceHelper
    {
        public bool MoveToSharedFolder()
        {
            string pathTo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "peoples.sqlite");
            bool retVal = true;

            if (!File.Exists(pathTo))
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                string[] resources = assembly.GetManifestResourceNames();

                foreach (string res in resources) {

                    if (res.EndsWith("sqlite")) {

                        try
                        {
                            //Right click the database select "Properties" and set "Build Action" to "EmbeddedResource"
                            var stream = assembly.GetManifestResourceStream(res);

                            using (var br = new BinaryReader(stream))
                            {
                                using (var bw = new BinaryWriter(new FileStream(pathTo, FileMode.Create)))
                                {
                                    byte[] buffer = new byte[2048];
                                    int length = 0;
                                    while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        bw.Write(buffer, 0, length);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            retVal = false;
                        }
                    }
                }
            }
            return retVal;
        }
    }
}
