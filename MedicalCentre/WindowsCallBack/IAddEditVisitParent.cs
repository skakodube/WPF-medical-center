using MedicalCentre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCentre.WindowsCallBack
{
    public interface IAddEditVisitParent
    {
        void EditFinished(object obj);
        void AddFinished(object obj);
    }
}
