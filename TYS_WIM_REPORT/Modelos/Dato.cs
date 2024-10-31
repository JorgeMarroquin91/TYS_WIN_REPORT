using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYS_WIM_REPORT.Modelos
{
    public class Dato
    {
        public long id { get; set; }
        public double SITE_NUMBER { get; set; }
        public string SITE_ID { get; set; }
        public double SERIAL_NUMBER { get; set; }
        public DateTime? DATE { get; set; }
        public TimeSpan? TIME { get; set; }
        public string? TimeString { get; set; }
        public Byte? LANE { get; set; }
        public string? LANE_DETAILS { get; set; }
        public string? DIRECTION { get; set; }
        public Int16? DIRECTION_NUMBER { get; set; }
        public Byte? SPEED { get; set; }
        public Byte? SPEED_MPH { get; set; }
        public Int16? CLASS_INDEX { get; set; }
        public string? CLASS { get; set; }
        public Int16? LENGTH { get; set; }
        public Byte? AXLES { get; set; }
        public Int16? WHEELBASE { get; set; }
        public Int16? VALIDITY { get; set; }
        public string? STRADDLE { get; set; }
        public string? OVERLOADED { get; set; }
        public int? GROSS { get; set; }
        public int? HEADWAY { get; set; }
        public Int16? GAP { get; set; }
        public int? TIME_GAP { get; set; }
        public Int16? LEGAL_STATUS { get; set; }
        public Int16? CHASSIS_CODE { get; set; }
        public Int16? TEMP { get; set; }
        public Int16? AX_WT1 { get; set; }
        public Int16? AX_WT2 { get; set; }
        public Int16? AX_WT3 { get; set; }
        public Int16? AX_WT4 { get; set; }
        public Int16? AX_WT5 { get; set; }
        public Int16? AX_WT6 { get; set; }
        public Int16? AX_WT7 { get; set; }
        public Int16? AX_WT8 { get; set; }
        public Int16? AX_WT9 { get; set; }
        public Int16? AX_WT10 { get; set; }
        public Int16? AX_WT11 { get; set; }
        public Int16? AX_WT12 { get; set; }
        public Int16? AX_WT13 { get; set; }
        public Int16? AX_WT14 { get; set; }
        public Int16? AX_WT15 { get; set; }
        public Int16? AX_WT16 { get; set; }
        public Int16? AX_WT17 { get; set; }
        public Int16? AX_WT18 { get; set; }
        public Int16? AX_WT19 { get; set; }
        public Int16? AX_WT20 { get; set; }
        public Int16? AX_WT21 { get; set; }
        public Int16? AX_WT22 { get; set; }
        public Int16? AX_WT23 { get; set; }
        public Int16? AX_WT24 { get; set; }
        public Int16? AX_WT25 { get; set; }
        public string? AXLE_TYPE_1 { get; set; }
        public string? AXLE_TYPE_2 { get; set; }
        public string? AXLE_TYPE_3 { get; set; }
        public string? AXLE_TYPE_4 { get; set; }
        public string? AXLE_TYPE_5 { get; set; }
        public string? AXLE_TYPE_6 { get; set; }
        public string? AXLE_TYPE_7 { get; set; }
        public string? AXLE_TYPE_8 { get; set; }
        public string? AXLE_TYPE_9 { get; set; }
        public string? AXLE_TYPE_10 { get; set; }
        public string? AXLE_TYPE_11 { get; set; }
        public string? AXLE_TYPE_12 { get; set; }
        public string? AXLE_TYPE_13 { get; set; }
        public string? AXLE_TYPE_14 { get; set; }
        public string? AXLE_TYPE_15 { get; set; }
        public string? AXLE_TYPE_16 { get; set; }
        public string? AXLE_TYPE_17 { get; set; }
        public string? AXLE_TYPE_18 { get; set; }
        public string? AXLE_TYPE_19 { get; set; }
        public string? AXLE_TYPE_20 { get; set; }
        public string? AXLE_TYPE_21 { get; set; }
        public string? AXLE_TYPE_22 { get; set; }
        public string? AXLE_TYPE_23 { get; set; }
        public string? AXLE_TYPE_24 { get; set; }
        public string? AXLE_TYPE_25 { get; set; }
        public Int16? AX_SP1 { get; set; }
        public Int16? AX_SP2 { get; set; }
        public Int16? AX_SP3 { get; set; }
        public Int16? AX_SP4 { get; set; }
        public Int16? AX_SP5 { get; set; }
        public Int16? AX_SP6 { get; set; }
        public Int16? AX_SP7 { get; set; }
        public Int16? AX_SP8 { get; set; }
        public Int16? AX_SP9 { get; set; }
        public Int16? AX_SP10 { get; set; }
        public Int16? AX_SP11 { get; set; }
        public Int16? AX_SP12 { get; set; }
        public Int16? AX_SP13 { get; set; }
        public Int16? AX_SP14 { get; set; }
        public Int16? AX_SP15 { get; set; }
        public Int16? AX_SP16 { get; set; }
        public Int16? AX_SP17 { get; set; }
        public Int16? AX_SP18 { get; set; }
        public Int16? AX_SP19 { get; set; }
        public Int16? AX_SP20 { get; set; }
        public Int16? AX_SP21 { get; set; }
        public Int16? AX_SP22 { get; set; }
        public Int16? AX_SP23 { get; set; }
        public Int16? AX_SP24 { get; set; }
        public Int16? FRONT_MIN_CHASSIS { get; set; }
        public Int16? FRONT_MAX_CHASSIS { get; set; }
        public Int16? MIDDLE_MIN_CHASSIS { get; set; }
        public Int16? MIDDLE_MAX_CHASSIS { get; set; }
        public Int16? REAR_MIN_CHASSIS { get; set; }
        public Int16? REAR_MAX_CHASSIS { get; set; }

        public Dato()
        {
            this.id = 0;
            SITE_NUMBER = 0;
            SITE_ID = string.Empty;
            SERIAL_NUMBER = 0;
            DATE = null;
            TIME = null;
            TimeString = null;
            LANE = null;
            LANE_DETAILS = null;
            DIRECTION = null;
            DIRECTION_NUMBER = null;
            SPEED = null;
            SPEED_MPH = null;
            CLASS_INDEX = null;
            CLASS = null;
            LENGTH = null;
            AXLES = null;
            WHEELBASE = null;
            VALIDITY = null;
            STRADDLE = null;
            OVERLOADED = null;
            GROSS = null;
            HEADWAY = null;
            GAP = null;
            TIME_GAP = null;
            LEGAL_STATUS = null;
            CHASSIS_CODE = null;
            TEMP = null;
            AX_WT1 = null;
            AX_WT2 = null;
            AX_WT3 = null;
            AX_WT4 = null;
            AX_WT5 = null;
            AX_WT6 = null;
            AX_WT7 = null;
            AX_WT8 = null;
            AX_WT9 = null;
            AX_WT10 = null;
            AX_WT11 = null;
            AX_WT12 = null;
            AX_WT13 = null;
            AX_WT14 = null;
            AX_WT15 = null;
            AX_WT16 = null;
            AX_WT17 = null;
            AX_WT18 = null;
            AX_WT19 = null;
            AX_WT20 = null;
            AX_WT21 = null;
            AX_WT22 = null;
            AX_WT23 = null;
            AX_WT24 = null;
            AX_WT25 = null;
            AXLE_TYPE_1 = null;
            AXLE_TYPE_2 = null;
            AXLE_TYPE_3 = null;
            AXLE_TYPE_4 = null;
            AXLE_TYPE_5 = null;
            AXLE_TYPE_6 = null;
            AXLE_TYPE_7 = null;
            AXLE_TYPE_8 = null;
            AXLE_TYPE_9 = null;
            AXLE_TYPE_10 = null;
            AXLE_TYPE_11 = null;
            AXLE_TYPE_12 = null;
            AXLE_TYPE_13 = null;
            AXLE_TYPE_14 = null;
            AXLE_TYPE_15 = null;
            AXLE_TYPE_16 = null;
            AXLE_TYPE_17 = null;
            AXLE_TYPE_18 = null;
            AXLE_TYPE_19 = null;
            AXLE_TYPE_20 = null;
            AXLE_TYPE_21 = null;
            AXLE_TYPE_22 = null;
            AXLE_TYPE_23 = null;
            AXLE_TYPE_24 = null;
            AXLE_TYPE_25 = null;
            AX_SP1 = null;
            AX_SP2 = null;
            AX_SP3 = null;
            AX_SP4 = null;
            AX_SP5 = null;
            AX_SP6 = null;
            AX_SP7 = null;
            AX_SP8 = null;
            AX_SP9 = null;
            AX_SP10 = null;
            AX_SP11 = null;
            AX_SP12 = null;
            AX_SP13 = null;
            AX_SP14 = null;
            AX_SP15 = null;
            AX_SP16 = null;
            AX_SP17 = null;
            AX_SP18 = null;
            AX_SP19 = null;
            AX_SP20 = null;
            AX_SP21 = null;
            AX_SP22 = null;
            AX_SP23 = null;
            AX_SP24 = null;
            FRONT_MIN_CHASSIS = null;
            FRONT_MAX_CHASSIS = null;
            MIDDLE_MIN_CHASSIS = null;
            MIDDLE_MAX_CHASSIS = null;
            REAR_MIN_CHASSIS = null;
            REAR_MAX_CHASSIS = null;
        }
    }
}
