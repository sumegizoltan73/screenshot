using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using System.IO;
using System.Xml;

namespace ScreenShot
{
    [SerializableAttribute()]
    [XmlRootAttribute("Options", Namespace = "", IsNullable = false)]
    public class Options : INotifyPropertyChanged
    {
        protected string DestinationField = String.Empty;

        [XmlElementAttribute("Destination")]
        public string Destination
        {
            get { return this.DestinationField; }
            set
            {
                if (this.DestinationField != value)
                {
                    this.DestinationField = value;
                    NotifyPropertyChanged("Destination");
                }
            }

        }

        protected int IntervalField = 5000;

        [XmlElementAttribute("Interval")]
        public int Interval
        {
            get { return this.IntervalField; }
            set
            {
                if (this.IntervalField != value)
                {
                    this.IntervalField = value;
                    NotifyPropertyChanged("Interval");
                } 
            }
        }

        protected string FileFormatField = "jpeg";

        [XmlElementAttribute("FileFormat")]
        public string FileFormat
        {
            get { return this.FileFormatField; }
            set
            {
                if (this.FileFormatField != value)
                {
                    this.FileFormatField = value;
                    NotifyPropertyChanged("FileFormat");
                } 
            }
        }

        protected bool IsSubfolderEnabledField = true;

        [XmlElementAttribute("IsSubfolderEnabled")]
        public bool IsSubfolderEnabled
        {
            get { return this.IsSubfolderEnabledField; }
            set
            {
                if (this.IsSubfolderEnabledField != value)
                {
                    this.IsSubfolderEnabledField = value;
                    NotifyPropertyChanged("IsSubfolderEnabled");
                } 
            }
        }

        protected void SaveConfig()
        {
            try
            {
                string filepath = String.Format("{0}\\{1}", Directory.GetCurrentDirectory(), "Options.xml");
                XmlSerializer serializer = new XmlSerializer(typeof(Options));
                using (XmlTextWriter writer = new XmlTextWriter(filepath, Encoding.UTF8))
                {
                    serializer.Serialize(writer, this);
                }
            }
            catch (Exception) 
            { 
            }
        }

        #region componentmodel
        public event PropertyChangedEventHandler PropertyChanged;

        public void InitComponent()
        {
            this.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            switch (args.PropertyName)
            {
                case "Destination":
                case "Interval":
                case "FileFormat":
                case "IsSubfolderEnabled":
                    this.SaveConfig();
                    break;
                default:
                    break;
            }
        }
        #endregion
    }

}
