using MediatR;
using OpeningHours.Responses;
using System;

namespace OpeningHours.Queries
{

    public class GetOpeningHoursByIdQuery : IRequest<OpeningHoursResponse>
    {
        public Guid OpeningHoursId { get; }

        public GetOpeningHoursByIdQuery(Guid openingHoursId)
        {
            OpeningHoursId = openingHoursId;
        }
    }
}

