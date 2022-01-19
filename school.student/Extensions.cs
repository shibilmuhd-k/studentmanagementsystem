using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using school.dashboard.Repository.IRepository;
using school.dashboard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school.dashboard
{
    public static partial class Extensions
    {
        public static IServiceCollection InjectServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();

            return services;
        }
    }
}
