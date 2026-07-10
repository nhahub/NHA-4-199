using HRManagementSystem.Enums;
using HRManagementSystem.DAL.Entities;

namespace HRManagementSystem.DAL.Entities
{
    public class Application : BaseEntity
    {
        public DateTime Date { get; set; }
        public AplicationStatus Status { get; set; }
        public JopStage Stage { get; set; }
        public int CandidateID { get; set; }
        public int RequisitionID { get; set; }

        //Navigation Properties

        public Candidate? Candidate { get; set; }

        public JobRequisition? JobRequisition { get; set; }
        public ICollection<Interview> Interviews { get; set; } = new List<Interview>();
        public HiringHistory? HiringHistory { get; set; }
    }
}
