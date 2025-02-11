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

namespace takattoFS2
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        int IndexOfBytes(byte[] searchBuffer, byte[] bytesToFind)
        {
            for (int i = 0; i < searchBuffer.Length - bytesToFind.Length; i++)
            {
                bool success = true;

                for (int j = 0; j < bytesToFind.Length; j++)
                {
                    if (searchBuffer[i + j] != bytesToFind[j])
                    {
                        success = false;
                        break;
                    }
                }

                if (success)
                {
                    return i;
                }
            }

            return -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string oldText = "BGMSoundResource.bml";
            string newText = "BGMSoundResource.eml";
            string fileName = Path.Combine(gameFolder, "sound00.pak"); ;
            byte[] fileBytes = File.ReadAllBytes(fileName),
            oldBytes = Encoding.UTF8.GetBytes(oldText),
            newBytes = Encoding.UTF8.GetBytes(newText);

            int index = IndexOfBytes(fileBytes, oldBytes);

            if (index < 0)
            {
                // Text was not found
                return;
            }

            byte[] newFileBytes =
                new byte[fileBytes.Length + newBytes.Length - oldBytes.Length];

            Buffer.BlockCopy(fileBytes, 0, newFileBytes, 0, index);
            Buffer.BlockCopy(newBytes, 0, newFileBytes, index, newBytes.Length);
            Buffer.BlockCopy(fileBytes, index + oldBytes.Length,
                newFileBytes, index + newBytes.Length,
                fileBytes.Length - index - oldBytes.Length);

            File.WriteAllBytes(fileName, newFileBytes);


        }
        private string gameFolder = PatcherSettings.GetValue(PatcherSettings.takatto00001);
        private void Test_Load(object sender, EventArgs e)
        {
        }

    }
}
