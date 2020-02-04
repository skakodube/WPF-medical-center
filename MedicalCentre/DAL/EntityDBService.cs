using MedicalCentre.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCentre.DAL
{
    class EntityDBService
    {
        EntityModel context = new EntityModel();


        public IEnumerable<VISIT> getVisits()
        {
            var query = from v in context.VISITs
                        join d in context.DOCTORs on v.DOCTOR equals d.IDD
                        join pat in context.PATIENTs on v.PATIENT equals pat.IDP
                        select v;

            //return new IEnumerable<VISIT>(query.ToList());
            return query.ToList();
        }


        public IEnumerable<PATIENT> getPatients()
        {
            var query = from p in context.PATIENTs
                        select p;

            return query.ToList();
        }

        public IEnumerable<DOCTOR> getDoctors()
        {
            var query = from d in context.DOCTORs
                        select d;

            return query.ToList();
        }



        public void insertVisit(VISIT v)
        {

                context.VISITs.Add(v);
                context.SaveChanges();
        }

        public void insertPatient(PATIENT p)
        {
            try
            {

                context.PATIENTs.Add(p);
                context.SaveChanges();

            }
            catch (SqlException)
            {
                throw;
            }
        }


        public void updateVisit(VISIT toEdit, VISIT newvisit)
        {

            VISIT query = (from visit in context.VISITs
                         where visit.IDV == toEdit.IDV
                         select visit).First();




            query.DOCTOR1 = newvisit.DOCTOR1;
            query.PATIENT1 = newvisit.PATIENT1;
            query.DATEOFVISIT = newvisit.DATEOFVISIT;

            context.SaveChanges();
        }


        public void updatePatient(PATIENT toEdit, PATIENT newpatient)
        {

            PATIENT query = (from patient in context.PATIENTs
                           where patient.IDP == toEdit.IDP
                           select patient).First();




            query.NAME = newpatient.NAME;
            query.SURNAME = newpatient.SURNAME;
            query.DATEOFBIRTH = newpatient.DATEOFBIRTH;
            query.ADDRESS = newpatient.ADDRESS;
            query.GENDER = newpatient.GENDER;

            context.SaveChanges();
        }


        public void deleteVisit(VISIT visitToDel)
        {
            
            context.VISITs.Remove(visitToDel);
            context.SaveChanges();
        }

        public void deletePatient(PATIENT patToDel)
        {

            context.PATIENTs.Remove(patToDel);
            context.SaveChanges();
        }

    }





}
