using Application.Entities.Base;

namespace Application.Entities
{
    public class Doctor : Entity
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int MobileNo { get; set; }
        public string Specialization { get; set; }
        public decimal Fees { get; set; }
    }
    public class Patient : Entity
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int MobileNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string AgeType { get; set; } //Major or Minor
        public bool IsAdmitted { get; set; }
        public int RoomId { get; set; }
        public int BillId { get; set; }
        public int AssignedDoctorId { get; set; }
    }
    public class Bill: Entity
    {
        public int BillId { get; set; }
        public decimal OPD_Fees { get; set; }
        public decimal Doctor_Fees { get; set; }
        public decimal Other_Fees { get; set; }
        public decimal Total_Fees { 
            get { return Total_Fees; } 
            set { Total_Fees = OPD_Fees + Doctor_Fees + Other_Fees; } 
        }
    }
    public class Room: Entity
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Charge { get; set; }
    }
    public class Brother: Entity
    {
        public int BrotherId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int MobileNo { get; set; }
    }
    public class Nurse : Entity
    {
        public int NurseId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int MobileNo { get; set; }
        public decimal Fees { get; set; }
    }
}