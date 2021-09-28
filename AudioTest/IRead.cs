using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioTest
{
    interface IRead
    {

        void StartReceivingData();

        void StopReceivingData();

        void StartReceivingRecordedData(string filePath);

    }
}
