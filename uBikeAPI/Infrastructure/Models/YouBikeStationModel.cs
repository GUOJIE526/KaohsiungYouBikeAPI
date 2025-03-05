using Newtonsoft.Json;
using System.Collections.Generic;
using static uBikeAPI.Infrastructure.Models.YouBikeStationModel;

namespace uBikeAPI.Infrastructure.Models
{
    public class Rootobject
    {
        public string contentType { get; set; }
        public bool isImage { get; set; }
        public Data data { get; set; }
        public string id { get; set; }
        public bool success { get; set; }
    }

    public class Data
    {
        public int retCode { get; set; }
        public string updated_at { get; set; }
        public List<YouBikeStationModel> retVal { get; set; }
    }

    public class YouBikeStationModel
    {
        /// <summary>
        /// 場站城市(中文)
        /// </summary>
        public string scity { get; set; }
        /// <summary>
        /// 場站城市(英文)
        /// </summary>
        public string scityen { get; set; }
        /// <summary>
        /// 場站名稱(中文)
        /// </summary>
        public string sna { get; set; }
        /// <summary>
        /// 場站區域(中文)
        /// </summary>
        public string sarea { get; set; }
        /// <summary>
        /// 地址(中文)
        /// </summary>
        public string ar { get; set; }
        /// <summary>
        /// 場站名稱(英文)
        /// </summary>
        public string snaen { get; set; }
        /// <summary>
        /// 場站區域(英文)
        /// </summary>
        public string sareaen { get; set; }
        /// <summary>
        /// 地址(英文)
        /// </summary>
        public string aren { get; set; }
        /// <summary>
        /// 站點代號
        /// </summary>
        public string sno { get; set; }
        /// <summary>
        /// 場站總停車格
        /// </summary>
        public string tot { get; set; }
        /// <summary>
        /// 場站目前車輛數量
        /// </summary>
        public string sbi { get; set; }
        /// <summary>
        /// 資料更新時間
        /// </summary>
        public string mday { get; set; }
        /// <summary>
        /// 緯度
        /// </summary>
        public string lat { get; set; }
        /// <summary>
        /// 經度
        /// </summary>
        public string lng { get; set; }
        /// <summary>
        /// 空位數量
        /// </summary>
        public string bemp { get; set; }
        /// <summary>
        /// 禁用狀態 (0:禁用, 1:正常)
        /// </summary>
        public int act { get; set; }
        public Sbi_Detail sbi_detail { get; set; }
    }

    public class Sbi_Detail
    {
        public string yb2 { get; set; }
        public string eyb { get; set; }
    }

}
