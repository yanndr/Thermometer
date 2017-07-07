using System;

namespace TemperatureLibrary.Converter
{
    public abstract class BaseConverter{
        protected IConverterFactory converterFactory;

        protected BaseConverter(IConverterFactory converterFactory)
        {
            this.converterFactory= converterFactory;
        }
    }
}