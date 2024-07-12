using GameViewer.Dal;
using GameViewer.Dal.Entities;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameViewer.Repository
{
    internal class GeneralRepository
    {
        private readonly GameViewerContext _context;
        public GeneralRepository()
        {
            _context=new GameViewerContext();
        }
        public void AddProvider(List<Provider> providers)
        {
            _context.Providers.AddRange(providers);
            _context.SaveChanges();
        }
        public void AddProviderParam(List<ProviderParam> providerParams)
        {
            _context.ProviderParams.AddRange(providerParams);
            _context.SaveChanges();
        }
        public void AddParamValue(List<ParamValue> paramValues)
        {
            _context.ParamValues.AddRange(paramValues);
            _context.SaveChanges();
        }

        public List<Provider> GetProviders()
        {
            return _context.Providers.ToList();
        }
        public List<ProviderParam> GetProviderParams()
        {
            return _context.ProviderParams.ToList();
        }
        public DataTable GetAllProviderParams()
        {
            var providerParams = _context.ProviderParams.ToList();

            var dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("ProviderId", typeof(string));
            dataTable.Columns.Add("Features", typeof(string));
            dataTable.Columns.Add("OrderId", typeof(int));
            dataTable.Columns.Add("Type", typeof(string));
            dataTable.Columns.Add("DefaultValue", typeof(string));

            foreach (var providerParam in providerParams)
            {
                var row = dataTable.NewRow();
                row["Id"] = providerParam.Id;
                row["ProviderId"] = providerParam.ProviderId;
                row["Name"] = providerParam.Name; 
                row["Features"] = providerParam.Features;
                row["OrderId"] = providerParam.OrderId;
                row["Type"] = providerParam.Type;
                row["DefaultValue"] = providerParam.DefaultValue;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
        //public DataTable GetPageValuesById(int pageId)
        //{
        //    var Parameters = _context.ProviderParams
        //        .Where(cp => cp.ProviderId == pageId)
        //        .OrderBy(cp => cp.OrderId)
        //        .ToList();

        //    var ParameterValues = _context.ParamValues
        //        .Where(cpv => Parameters.Select(cp => cp.Id).Contains(cpv.ParameterId))
        //        .ToList();

        //    var dataTable = new DataTable();

        //    dataTable.Columns.Add("Id", typeof(int));
        //    foreach (var param in Parameters)
        //    {
        //        dataTable.Columns.Add(param.ColumnName, typeof(string));
        //    }

        //    var groupedValues = ParameterValues
        //        .GroupBy(cpv => cpv.RowId)
        //        .ToDictionary(g => g.Key, g => g.ToList());

        //    foreach (var group in groupedValues)
        //    {
        //        var row = dataTable.NewRow();
        //        row["Id"] = group.Key;

        //        foreach (var param in Parameters)
        //        {
        //            var value = group.Value.FirstOrDefault(v => v.ParameterId == param.Id)?.Value;
        //            row[param.ColumnName] = value ?? param.DefaultValue;
        //        }

        //        dataTable.Rows.Add(row);
        //    }

        //    return dataTable;
        //}

    }
}
