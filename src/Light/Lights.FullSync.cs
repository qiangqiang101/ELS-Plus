﻿using ELS.FullSync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELS.Light
{
    partial class Lights : IFullSyncComponent
    {
        public Dictionary<string, object> GetData()
        {

            var dic = new Dictionary<string, object>();
            var prm = new Dictionary<int, object>();
            foreach (Extra.Extra e in _extras.PRML.Values)
            {
                prm.Add(e.Id, e.GetData());
#if DEBUG
                CitizenFX.Core.Debug.WriteLine($"Added {e.Id} to prml sync data");
#endif
            }
            var sec = new Dictionary<int, object>();
            foreach (Extra.Extra e in _extras.SECL.Values)
            {
                sec.Add(e.Id, e.GetData());
#if DEBUG
                CitizenFX.Core.Debug.WriteLine($"Added {e.Id} to secl sync data");
#endif
            }
            var wrn = new Dictionary<int, object>();
            foreach (Extra.Extra e in _extras.WRNL.Values)
            {
                wrn.Add(e.Id, e.GetData());
#if DEBUG
                CitizenFX.Core.Debug.WriteLine($"Added {e.Id} to wrnl sync data");
#endif
            }
            if (prm != null && prm.Count > 0)
            {
                dic.Add("PRML", prm);
#if DEBUG
                CitizenFX.Core.Debug.WriteLine($"added PRML data");
#endif
            }
            if (sec != null && sec.Count > 0)
            {
                dic.Add("SECL", sec);
#if DEBUG
                CitizenFX.Core.Debug.WriteLine($"addded secl data");
#endif
            }
            if (wrn != null && wrn.Count > 0)
            {
                dic.Add("WRNL", wrn);
#if DEBUG
                CitizenFX.Core.Debug.WriteLine($"added wrnl data");
#endif
            }
            if (_extras.SBRN != null)
            {
                dic.Add("SBRN", _extras.SBRN.GetData());
#if DEBUG
                CitizenFX.Core.Debug.WriteLine($"Got SBRN data");
#endif
            }
            if (_extras.SCL != null)
            {
                dic.Add("SCL", _extras.SCL.GetData());
#if DEBUG
                CitizenFX.Core.Debug.WriteLine($"Got SCL data");
#endif
            }
            if (_extras.TDL != null)
            {
                dic.Add("TDL", _extras.TDL.GetData());
#if DEBUG
                CitizenFX.Core.Debug.WriteLine($"Got TDL data");
#endif
            }
            dic.Add("BRD", _extras.BRD.GetData());
            dic.Add("PrmPatt", CurrentPrmPattern);
            dic.Add("SecPatt", CurrentSecPattern);
            dic.Add("WrnPatt", CurrentWrnPattern);
            return dic;
        }

        public void SetData(IDictionary<string, object> data)
        {
#if DEBUG

#endif
            if (data.ContainsKey("PRML"))
            {
#if DEBUG
                CitizenFX.Core.Debug.WriteLine($"Got PRML data");
#endif
                IDictionary<string, object> prm = (IDictionary<string, object>)data["PRML"];
                foreach (Extra.Extra e in _extras.PRML.Values)
                {
                    e.SetData((IDictionary<string, object>)prm[$"{e.Id}"]);
#if DEBUG
                    CitizenFX.Core.Debug.WriteLine($"Added {e.Id} from prml sync data");
#endif
                }
            }
            if (data.ContainsKey("SECL"))
            {
#if DEBUG
                CitizenFX.Core.Debug.WriteLine($"Got SECL DAta");
#endif
                IDictionary<string, object> sec = (IDictionary<string, object>)data["SECL"];
                foreach (Extra.Extra e in _extras.SECL.Values)
                {
                    e.SetData((IDictionary<string, object>)sec[$"{e.Id}"]);
#if DEBUG
                    CitizenFX.Core.Debug.WriteLine($"Added {e.Id} from secl sync data");
#endif
                }
            }
            if (data.ContainsKey("WRNL"))
            {
#if DEBUG
                CitizenFX.Core.Debug.WriteLine($"Got WRNL data");
#endif
                IDictionary<string, object> wrn = (IDictionary<string, object>)data["WRNL"];
                foreach (Extra.Extra e in _extras.WRNL.Values)
                {
                    e.SetData((IDictionary<string, object>)wrn[$"{e.Id}"]);
#if DEBUG
                    CitizenFX.Core.Debug.WriteLine($"Added {e.Id} from wrnl sync data");
#endif
                }
            }
            if (data.ContainsKey("SBRN"))
            {
                _extras.SBRN.SetData((IDictionary<string, object>)data["SBRN"]);
            }
            if (data.ContainsKey("SCL"))
            {
                _extras.SBRN.SetData((IDictionary<string, object>)data["SCL"]);
            }
            if (data.ContainsKey("TDL"))
            {
                _extras.SBRN.SetData((IDictionary<string, object>)data["TDL"]);
            }
            if (data.ContainsKey("BRD"))
            {
                _extras.BRD.SetData((IDictionary<string, object>)data["BRD"]);
            }
            if (data.ContainsKey("PrmPatt"))
            {
                CurrentPrmPattern = int.Parse(data["PrmPatt"].ToString());
            }
            if (data.ContainsKey("SecPatt"))
            {
                CurrentSecPattern = int.Parse(data["SecPatt"].ToString());
            }
            if (data.ContainsKey("WrnPatt"))
            {
                CurrentWrnPattern = int.Parse(data["WrnPatt"].ToString());
            }
        }
    }
}
