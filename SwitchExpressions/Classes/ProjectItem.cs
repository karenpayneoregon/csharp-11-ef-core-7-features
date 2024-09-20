using System;

namespace SwitchExpressions.Classes
{
    public class ProjectItem
    {
        public int PlatFormId { get; set; }
        public int SectionId { get; set; }
        public int Result { get; set; }
    }

    public static class ProjectOperations
    {

        public static void Demo()
        {
            ProjectItem project = new() { PlatFormId = 3, SectionId = 2 };
            Console.WriteLine(project.GetResult());

            project.PlatFormId = 2;
            project.SectionId = 4;
            Console.WriteLine(project.GetResult());

            Console.ReadLine();
        }

        /// <summary>
        /// Assign <see cref="ProjectItem.Result"/> from
        /// asserting PlatFormId then using 'when' on SectionId
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static int GetResult(this ProjectItem sender) => sender.PlatFormId switch
        {
            1 when sender.SectionId == 1 => 1,
            1 when sender.SectionId == 2 => 2,
            1 when sender.SectionId == 4 => 3,
            3 when sender.SectionId == 1 => 4,
            3 when sender.SectionId == 2 => 5,
            3 when sender.SectionId == 4 => 6,
            2 when sender.SectionId == 1 => 7,
            2 when sender.SectionId == 2 => 8,
            2 when sender.SectionId == 4 => 9,
            _ => sender.Result
        };
    }
}