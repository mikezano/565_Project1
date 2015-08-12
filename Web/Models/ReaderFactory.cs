using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public enum ReaderType
    {
        XML,
        JSON
    }
    public class ReaderFactory
    {
        public IMenuReader CreateReader(ReaderType type)
        {
            switch(type){
                case ReaderType.XML:
                    return new XmlMenuReader();
                case ReaderType.JSON:
                    return new JsonMenuReader();
            }

            return null;
        }

        public IMenuReader CreateReader()
        {
            return CreateReader(ReaderType.XML);
        }

    }
}