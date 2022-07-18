using MediatR;
using OpeningHours.Responses;
using System;
using System.Collections.Generic;

namespace OpeningHours.Queries
{
    public class GetAllOpeningQuery : IRequest<List<OpeningHoursResponse>>
    {

    }
}
