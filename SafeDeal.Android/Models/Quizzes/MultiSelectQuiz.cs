using Android.OS;

using SafeDeal.Helpers;

namespace SafeDeal.Android.Models.Quizzes
{
    public class MultiSelectQuiz : OptionsQuiz<string>
    {
        public MultiSelectQuiz(string question, int[] answer, string[] options, bool solved) : base(question, answer, options, solved)
        {
            QuizType = QuizType.MultiSelect;
        }

        public MultiSelectQuiz(Parcel inObj) : base(inObj)
        {
            Options = inObj.CreateStringArray();
        }

        public override string GetStringAnswer()
        {
            return AnswerHelper.GetAnswer(Answer, Options);
        }

        public override void WriteToParcel(Parcel dest, ParcelableWriteFlags flags)
        {
            base.WriteToParcel(dest, flags);
            dest.WriteStringArray(Options);
        }
    }
}