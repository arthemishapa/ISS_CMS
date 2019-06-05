using System.Collections.Generic;

namespace CMS.CMS.DAL.Entities
{
    // TODO: submission session
    // TODO Field for Grade
    public class Submission
    {
        public int Id { get; set; }

        public int ConferenceId { get; set; }
        public string AuthorId { get; set; }

        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Filename { get; set; }

        public User Author { get; set; }
        public Conference Conference { get; set; }

        public IEnumerable<SubmissionReview> Reviews { get; set; }
        public int getId() { return Id; }
        public void setId(int id) { Id = id; }
        public int getConferenceId() { return ConferenceId; }
        public void setConferenceId(int id) { ConferenceId = id; }

        public string getAuthorId() { return AuthorId; }
        public void setAuthorId(string id) { AuthorId = id; }

        public string getTitle() { return Title; }
        public void setTitle(string title) { Title = title; }
        public string getAbstract() { return Abstract; }
        public void setAbstract(string _abstract) { Abstract = _abstract; }
        public string getFileName() { return Filename; }
        public void setFileName(string fileName) { Filename = fileName; }

    }
}