﻿using System;
using System.Collections.Generic;
using System.Linq;
using Food.EntityFramework;
using Food.EntityFramework.Entities;
using FoodAdmin.Dto.Sample;

namespace FoodAdmin.Service
{
    public class SampleService : ISampleService
    {
        private readonly IRepository<Sample> _sampleRepository;

        public SampleService( IRepository<Sample> sampleRepository )
        {
            _sampleRepository = sampleRepository;
        }

        public List<SampleDto> GetSamples()
        {
            List<Sample> samples = _sampleRepository.All.ToList();

            return samples.ConvertAll( Convert );
        }

        public SampleDto GetSample( int sampleId )
        {
            if ( sampleId == 0 )
            {
                return CreateSample();
            }

            Sample sample = _sampleRepository.All.FirstOrDefault( item => item.Id == sampleId );
            if ( sample != null )
            {
                return Convert( sample );
            }

            return null;
        }

        public SampleDto SaveSample( SampleDto sampleDto )
        {
            Sample sample = _sampleRepository.GetItem( sampleDto.SampleId )
                ?? new Sample
                {
                    CreationDateTime = DateTime.Now
                };

            sample.Name = sampleDto.Name;
            sample.Description = sampleDto.Description;

            sample = _sampleRepository.Save( sample );

            return Convert( sample );
        }

        public SampleDto CreateSample()
        {
            return new SampleDto
            {
                SampleId = 0,
                Name = "Sample",
                Description = "Описание созданного экземпляра"
            };
        }

        private SampleDto Convert( Sample sample )
        {
            return new SampleDto
            {
                SampleId = sample.Id,
                Name = sample.Name,
                Description = sample.Description
            };
        }
    }
}