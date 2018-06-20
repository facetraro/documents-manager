using DocumentsManager.Data.DA.Handler;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtosAndModels
{
    public class DocumentDtoAverage
    {
        public class DocumentAverageDto
        {
            public Guid Id { get; set; }
            public double Average { get; set; }
            public string Title { get; set; }
            public DocumentAverageDto(Document aDocument)
            {
                Id = aDocument.Id;
                Average = CalculateAverage(aDocument.Id);
                Title = aDocument.Title;
            }
            public DocumentAverageDto()
            {
                Id = Guid.NewGuid();
                Title = "";
                Average = 0;
            }
            public double CalculateAverage(Guid Id)
            {
                double average = 0;
                ReviewContext rContext = new ReviewContext();
                List<Review> reviewsDoci = rContext.GetReviewsFromDocument(Id);
                foreach (Review revi in reviewsDoci)
                {
                    average = average + revi.Rating;
                }
                average = average / reviewsDoci.Count;
                return average;
            }
            public override bool Equals(object obj)
            {
                DocumentAverageDto anotherDocument = obj as DocumentAverageDto;
                if ((System.Object)anotherDocument == null)
                {
                    return false;
                }
                return Id.Equals(anotherDocument.Id);
            }
        }
    }
}
