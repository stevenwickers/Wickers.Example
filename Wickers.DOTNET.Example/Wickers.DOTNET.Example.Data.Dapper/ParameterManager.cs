using Dapper;
using System;
using System.Collections.Generic;
using Wickers.DOTNET.Example.Data.Dapper.Model;

namespace Wickers.DOTNET.Example.Data.Dapper
{
    public class ParameterManager
    {
        public static DynamicParameters CreateParameters(List<ParameterModel> Parameters = null)
        {
            DynamicParameters parameters = new DynamicParameters();

            if (Parameters != null)
            {
                foreach (ParameterModel param in Parameters)
                {
                    object paramValue = param.Value;

                    if (paramValue is String)
                    {
                        paramValue = paramValue.ToString().Trim();
                    }

                    parameters.Add($"@{param.Name}", paramValue, param.DataType, param.Direction, param.Size);
                }
            }

            return parameters;

        }
        
        public static T GetParameterValue<T>(DynamicParameters Parameters, string ParameterName)
        {
            return Parameters.Get<T>(ParameterName);
        }
    }
}
