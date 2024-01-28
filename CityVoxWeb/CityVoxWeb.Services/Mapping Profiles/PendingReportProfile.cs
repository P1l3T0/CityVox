using AutoMapper;
using CityVoxWeb.Data.Models.IssueEntities;
using CityVoxWeb.Data.Models.IssueEntities.Enumerators.Report;
using CityVoxWeb.Data.Models.IssueEntities.Pending;
using CityVoxWeb.DTOs.Issues.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityVoxWeb.Services.Mapping_Profiles.Issue_Profiles
{
    public class PendingReportProfile : Profile
    {
        public PendingReportProfile()
        {
            CreateMap<UpdateReportDto, PendingReport>()
                    .ForMember(dest => dest.ReportTime,
                                opt => opt.MapFrom(src => DateTime.UtcNow))
                    .ForMember(dest => dest.DueBy,
                                opt => opt.MapFrom(src => DateTime.UtcNow.AddMonths(3)))
                    .ForMember(dest => dest.Type,
                                opt => opt.MapFrom(src => (ReportType)src.Type))
                    .ForMember(dest => dest.Status,
                                opt => opt.MapFrom(src => Enum.Parse<ReportStatus>("Reported", true)));
            CreateMap<PendingReport, ExportReportDto>();
            CreateMap<Report, PendingReport>();
            CreateMap<UpdateReportDto, Report>();
            CreateMap<PendingReport, Report>();
        }
    }
}
