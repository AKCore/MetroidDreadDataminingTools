using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkUI.Forms;
using DarkUI.Collections;
using DarkUI.Controls;
namespace MetroidDreadDatamine
{
    public partial class MainForm : DarkForm
    {
        public byte[] tunablesFile;
        public struct DamagableData
        {
            public string ClassName;
            public short ClassType;
            public float Damage;
        }

        public struct DamagableLocation
        {
            public DamagableLocation(int x, int y, int z)
            {
                offset = x;
                textLen = y;
                damageOffset = z;
            }

            public int offset;
            public int textLen;
            public int damageOffset;
        }

        public List<DamagableData> damagables = new List<DamagableData>();
        public List<DamagableLocation> damageLocs = new List<DamagableLocation>();


        public MainForm()
        {
            InitializeComponent();

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                tunablesFile = File.ReadAllBytes("tunables.btunda");

                SearchForTunable();
                foreach (DamagableLocation d in damageLocs)
                {
                    ConvertToDamagablesData(d.offset, d.textLen, d.damageOffset);
                }

                foreach (DamagableData d in damagables)
                {
                    Console.WriteLine("ClassName:" + d.ClassName);
                    Console.WriteLine("ClassType:" + d.ClassType);
                    Console.WriteLine("Damage:" + d.Damage);
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.RowTemplate.Clone();
                    row.CreateCells(dataGridView1, d.ClassName, d.ClassType, d.Damage);
                    dataGridView1.Rows.Add(row);
                }


            }

            catch (Exception ex)
            {
                DarkMessageBox.Show(this, ex.StackTrace, "Failed To Load Data", MessageBoxButtons.OK);
            }
        }

        private void ConvertToDamagablesData(int offset, int textLen, int damageOffset)
        {
            try
            {
                DamagableData data = new DamagableData();
                List<byte> bytes = new List<byte>();

                for (int i = 0; i < textLen; i++)
                    bytes.Add(tunablesFile[offset + i]);

                byte[] textbytes = bytes.ToArray();

                data.ClassName = Encoding.ASCII.GetString(textbytes);

                data.ClassType = BitConverter.ToInt16(new byte[] { tunablesFile[offset + textLen + 1], tunablesFile[offset + textLen + 2] }, 0);

                byte[] damageFloat = new byte[] { tunablesFile[offset + textLen + damageOffset + 1], tunablesFile[offset + textLen + damageOffset + 2], tunablesFile[offset + textLen + damageOffset + 3], tunablesFile[offset + textLen + damageOffset + 4] };
                data.Damage = ToFloat(damageFloat);

                damagables.Add(data);
            }
            catch(Exception ex)
            {
                //DarkMessageBox.Show(this, ex.StackTrace, "Failed To Load Data", MessageBoxButtons.OK);
            }
        }

        static float ToFloat(byte[] input)
        {
            try
            {
                byte[] newArray = new[] { input[0], input[1], input[2], input[3] };
                return BitConverter.ToSingle(newArray, 0);
            }
            catch { return 0; }
        }
        public byte[] tunableString = new byte[] {0x43, 0x54, 0x75, 0x6e, 0x61, 0x62, 0x6c, 0x65 };
        public void SearchForTunable()
        {
            int lastFind = 0;
            
            for (int tunable = 0; tunable < tunablesFile.Length;)
            {
                try
                {
                    DamagableLocation loc = new DamagableLocation();
                    int strLen = 0;
                    List<byte> strList = new List<byte>();
                        
                    lastFind = ByteSearch(tunablesFile, tunableString, tunable);
                    if (lastFind != -1)
                    {
                        strList.Clear();
                        bool reading = true;
                        int j = 0;
                        while (reading)
                        {
                            if (tunablesFile[j + lastFind] != 0)
                            {
                                strList.Add(tunablesFile[j + lastFind]);
                            }
                            else
                            {
                                reading = false;
                                strLen = strList.Count;
                                loc.textLen = strLen;
                            }
                            j++;
                        }
                        int type = BitConverter.ToInt16(tunablesFile, lastFind + strLen + 1);
                        if (type == 17001) // This type is Samus' weapon. 
                        {
                            //Found a damagable struct
                            loc.offset = lastFind;
                            Console.WriteLine("Found type at " + lastFind);
                            loc.damageOffset = 8;
                            Console.WriteLine("Found damage at " + (lastFind + strLen + 1 + 2 + 5));
                            damageLocs.Add(loc);
                            tunable = (strLen + lastFind);

                        }
                        else
                        {
                            tunable = (lastFind + strLen);
                        }
                    }
                    else
                        return;
                }
                catch(Exception ex)
                {
                    tunable += 1;
                    Console.WriteLine(ex.StackTrace);
                    break;
                }
            }
        }
        static int ByteSearch(byte[] searchIn, byte[] searchBytes, int start = 0)
        {
            int found = -1;
            bool matched = false;
            //only look at this if we have a populated search array and search bytes with a sensible start
            if (searchIn.Length > 0 && searchBytes.Length > 0 && start <= (searchIn.Length - searchBytes.Length) && searchIn.Length >= searchBytes.Length)
            {
                //iterate through the array to be searched
                for (int i = start; i <= searchIn.Length - searchBytes.Length; i++)
                {
                    //if the start bytes match we will start comparing all other bytes
                    if (searchIn[i] == searchBytes[0])
                    {
                        if (searchIn.Length > 1)
                        {
                            //multiple bytes to be searched we have to compare byte by byte
                            matched = true;
                            for (int y = 1; y <= searchBytes.Length - 1; y++)
                            {
                                if (searchIn[i + y] != searchBytes[y])
                                {
                                    matched = false;
                                    break;
                                }
                            }
                            //everything matched up
                            if (matched)
                            {
                                found = i;
                                break;
                            }

                        }
                        else
                        {
                            //search byte is only one bit nothing else to do
                            found = i;
                            break; //stop the loop
                        }

                    }
                }

            }
            return found;
        }
    }
}
