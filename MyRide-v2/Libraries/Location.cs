using System;

namespace Location
{
    public class location
    {
        private float latitude;
        private float longitude;
        public float Latitude
        {
            set
            {
                latitude = value;
            }
            get
            {
                return latitude;
            }
        }
        public float Longitude
        {
            set
            {
                longitude = value;
            }
            get
            {
                return longitude;
            }
        }
        public location()
        {
            Latitude = 0;
            Longitude = 0;
        }
        public location(float la,float lo)
        {
            Latitude = la;
            Longitude = lo;
        }
        public void setLocation(float la, float lo)
        {
            Latitude = la;
            Longitude = lo;
        }
    }
}
