﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();

        IResult Add(Rental rental);

        IResult Delete(Rental rental);

        IResult Update(Rental rental);

        IDataResult<Rental> GetById(int id);

        IDataResult<List<RentalDetailDto>> GetRentalDetails();
    }
}
