using System;
using BaseSwears;
using System.Management.Automation;

namespace BaseSwears.Powershell5 {
    [Cmdlet(VerbsData.ConvertTo, "BaseSwears")]
    public class ConvertToBaseSwears : Cmdlet {
        [Parameter(Mandatory = true)]
        public string Path { get; set; }

        [Parameter(Mandatory = true)]
        public string OutPath { get; set; }

        protected override void ProcessRecord() {
            using (SwearEncoder enc = new SwearEncoder(Path))
                WriteObject(enc.EncodeBinary(OutPath));
        }
    }
}
