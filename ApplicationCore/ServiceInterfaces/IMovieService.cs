﻿using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        IEnumerable<MovieCardResponseModel> GetHighestGrossingMovies();

        MovieDetailsResponseModel GetMovieDetailsById(int id);
    }
}
