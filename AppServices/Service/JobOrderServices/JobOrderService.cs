﻿using AppCore.Entities;
using AppCore.Enums;
using AppPersistence.Repositories.GenericRepo;
using AppServices.DTOs.JobOrderDTOs;
using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Service.JobOrderServices {
    public class JobOrderService:IJobOrderService {

        private readonly IGenericRepository<JobOrder> _repository;

        public JobOrderService(IGenericRepository<JobOrder> repository) { 
            _repository = repository;
        }


        public void CreateJob(CreateJobOrderDTO createJobOrderDTO) {
            var jobOrder = new JobOrder { 
                Title = createJobOrderDTO.Title,
                Description = createJobOrderDTO.Description,
                Priority = createJobOrderDTO.Priority,
                EstimatedCompletionDate = createJobOrderDTO.EstimatedCompletionDate,
                Status = JobOrderStatusEnum.Open,
                CreatedDate = createJobOrderDTO.CreatedDate
            };

            _repository.Create(jobOrder);
        }

        public void DeleteJobOrder(int id) {
            _repository.Delete(_repository.GetById(id));
        }

        public List<JobOrderDTO> GetAllJobOrders() {
            var jobOrderList = _repository.GetAll();

            return jobOrderList.Select(o => new JobOrderDTO {
                Id = o.Id,
                Title = o.Title,
                Description = o.Description,
                Priority = o.Priority,
                EstimatedCompletionDate= o.EstimatedCompletionDate,
                Status = o.Status,
                CreatedDate = o.CreatedDate,
                UpdatedDate = o.UpdatedDate
            }).ToList();
        }

        public JobOrderDTO GetJobOrderById(int id) {
            var jobOrder = _repository.GetById(id);
            return new JobOrderDTO {
                Id = jobOrder.Id,
                Title = jobOrder.Title,
                Description = jobOrder.Description,
                Priority = jobOrder.Priority,
                EstimatedCompletionDate = jobOrder.EstimatedCompletionDate,
                Status = jobOrder.Status,
                CreatedDate = jobOrder.CreatedDate,
                UpdatedDate = jobOrder.UpdatedDate
            };
        }

        public JobOrderReportDTO GetJobOrderReport() {
            var jobOrders = _repository.GetAll();
            int openOrders = 0;
            int closedOrders = 0;
            int cancelledOrders = 0;
            var jobOrderReportDTO = new JobOrderReportDTO {
                JobOrderDetails = new List<JobOrderDetailsDTO>()
            };
            foreach(var jobOrder in jobOrders) {
                string Status;
                if(jobOrder.Status == JobOrderStatusEnum.Open) {
                    Status = "Open";
                    openOrders++;
                } 
                if(jobOrder.Status == JobOrderStatusEnum.Cancelled) {
                    Status = "Cancelled";
                    cancelledOrders++;
                } else {
                    Status = "Closed";
                    closedOrders++;
                }


                string Priority = PriorityEnum.Low == jobOrder.Priority ? "Low" : PriorityEnum.Medium == jobOrder.Priority ? "Medium" : "High";

                var jobOrderReport = new JobOrderDetailsDTO {
                    Title = jobOrder.Title,
                    Description = jobOrder.Description,
                    Priority = Priority,
                    EstimatedCompletionDate = jobOrder.EstimatedCompletionDate,
                    Status = Status,
                    CreatedDate = jobOrder.CreatedDate,
                    UpdatedDate = jobOrder.UpdatedDate
                };
                jobOrderReportDTO.JobOrderDetails.Add(jobOrderReport);

            }
            jobOrderReportDTO.TotalOpenOrders = openOrders;
            jobOrderReportDTO.TotalClosedOrders = closedOrders;
            jobOrderReportDTO.TotalCancelledOrders = cancelledOrders;
            return jobOrderReportDTO;
        }

        public List<JobOrderDTO> GetJobOrdersByStatus(JobOrderStatusEnum status) {
            var jobOrders = _repository.GetAll();
            return jobOrders
                .Where(jo => jo.Status == status)
                .Select(jo => new JobOrderDTO {
                    Id=jo.Id,
                    Title = jo.Title,
                    Description = jo.Description,
                    Priority = jo.Priority,
                    EstimatedCompletionDate= jo.EstimatedCompletionDate,
                    Status = jo.Status,
                    CreatedDate = jo.CreatedDate,
                    UpdatedDate = jo.UpdatedDate
            }).ToList();

        }

        public void UpdateJobOrder(JobOrderDTO jobOrderDTO) {
            var jobOrder = new JobOrder {
                Id = jobOrderDTO.Id,
                Title = jobOrderDTO.Title,
                Description = jobOrderDTO.Description,
                Priority = jobOrderDTO.Priority,
                EstimatedCompletionDate = jobOrderDTO.EstimatedCompletionDate,
                Status = jobOrderDTO.Status,
                CreatedDate = jobOrderDTO.CreatedDate,
                UpdatedDate = jobOrderDTO.UpdatedDate
            };
            _repository.Update(jobOrder);
        }
    }
}
