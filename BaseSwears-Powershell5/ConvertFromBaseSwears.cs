using System;
using BaseSwears;
using System.Management.Automation;

namespace BaseSwears.Powershell5 {
    [Cmdlet(VerbsData.ConvertFrom, "BaseSwears")]
    public class ConvertFromBaseSwears: Cmdlet {
        [Parameter(Mandatory = true)]
        public string Path { get; set; }

        [Parameter(Mandatory = true)]
        public string OutPath { get; set; }

        protected override void ProcessRecord() {
            using (SwearDecoder enc = new SwearDecoder(Path))
                WriteObject(enc.DecodeBinary(OutPath));
        }
    }
}
