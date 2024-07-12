using GameViewer.Dal;
using GameViewer.Dal.Entities;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<ParamValue> GetParamValues()
        {
            return _context.ParamValues.ToList();
        }

    }
}
