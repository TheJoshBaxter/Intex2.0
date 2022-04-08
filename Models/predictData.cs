using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace UtahTraffix.Models
{
    public class predictData
    {
        //[Key]
        //[Required]
        //public float MILEPOINT { get; set; } //There three used to be doubles
        //public float LAT_UTM_Y { get; set; }
        //public float LONG_UTM_X { get; set; }
        //public float CITY { get; set; }
        //public float COUNTY_NAME { get; set; }
        //public float WORK_ZONE_RELATED { get; set; }
        //public float PEDESTRIAN_INVOLVED { get; set; }
        //public float BICYCLIST_INVOLVED { get; set; }
        //public float MOTORCYCLE_INVOLVED { get; set; }
        //public float IMPROPER_RESTRAINT { get; set; }
        //public float UNRESTRAINED { get; set; }
        //public float DUI { get; set; }
        //public float INTERSECTION_RELATED { get; set; }
        //public float WILD_ANIMAL_RELATED { get; set; }
        //public float DOMESTIC_ANIMAL_RELATED { get; set; }
        //public float OVERTURN_ROLLOVER { get; set; }
        //public float COMMERCIAL_MOTOR_VEH_INVOLVED { get; set; }
        //public float TEENAGE_DRIVER_INVOLVED { get; set; }
        //public float OLDER_DRIVER_INVOLVED { get; set; }
        //public float NIGHT_DARK_CONDITION { get; set; }
        //public float SINGLE_VEHICLE { get; set; }
        //public float DISTRACTED_DRIVING { get; set; }
        //public float DROWSY_DRIVING { get; set; }
        //public float ROADWAY_DEPARTURE { get; set; }


        public float PEDESTRIAN_INVOLVED { get; set; }
        public float MOTORCYCLE_INVOLVED { get; set; }
        public float BICYCLIST_INVOLVED { get; set; }
        public float OVERTURN_ROLLOVER{ get; set; }
        public float UNRESTRAINED{ get; set; }
        public float DUI { get; set; }
        public float ROADWAY_DEPARTURE { get; set; }
        public float INTERSECTION_RELATED { get; set; }
        public float OLDER_DRIVER_INVOLVED { get; set; }
        public float CITY_WEST_JORDAN { get; set; }
        public float WILD_ANIMAL_RELATED { get; set; }
        public float SINGLE_VEHICLE { get; set; }
        public float COUNTY_NAME_SALT_LAKE { get; set; }
        public float CITY_ST_GEORGE { get; set; }
        public float CITY_PARK_CITY { get; set; }
        public float CITY_MOAB { get; set; }
        public float CITY_WASHINGTON_TERRACE { get; set; }
        public float CITY_PRICE { get; set; }
        public float CITY_OREM { get; set; }
        public float CITY_SOUTH_WEBER { get; set; }

public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {


            PEDESTRIAN_INVOLVED,
            MOTORCYCLE_INVOLVED,
            BICYCLIST_INVOLVED,
            OVERTURN_ROLLOVER,
            UNRESTRAINED,
            DUI,
            ROADWAY_DEPARTURE,
            INTERSECTION_RELATED,
            OLDER_DRIVER_INVOLVED,
            CITY_WEST_JORDAN,
            WILD_ANIMAL_RELATED,
            SINGLE_VEHICLE,
            COUNTY_NAME_SALT_LAKE,
            CITY_ST_GEORGE,
            CITY_PARK_CITY,
            CITY_MOAB,
            CITY_WASHINGTON_TERRACE,
            CITY_PRICE,
            CITY_OREM,
            CITY_SOUTH_WEBER


            };
            int[] dimensions = new int[] { 1, 20 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}
