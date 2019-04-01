using Abp.Application.Services;
using System;
using System.Threading.Tasks;
using VEducation.Data.Model;

namespace VEducation.Service.Company
{
    public interface IFeatureServicce : IApplicationService
    {
        Task<Feature> Create(string name, string desc);
        Task<Feature> Delete(string name, string desc);
        Task<Feature> Update(string name, string desc);
    }
}