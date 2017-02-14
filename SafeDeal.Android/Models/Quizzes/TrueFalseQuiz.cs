using Android.OS;

using SafeDeal.Helpers;

namespace SafeDeal.Android.Models.Quizzes
{
	public class TrueFalseQuiz : Quiz<bool>
	{
		public TrueFalseQuiz (string question, bool answer, bool solved) : base (question, answer, solved)
		{
			QuizType = SafeDeal.Android.Models.Quizzes.QuizType.TrueFalse;
		}

		public TrueFalseQuiz (Parcel inObj) : base (inObj)
		{
			Answer = ParcelableHelper.ReadBoolean (inObj);
			QuizType = SafeDeal.Android.Models.Quizzes.QuizType.TrueFalse;
		}

		public override string GetStringAnswer ()
		{
			return Answer.ToString ();
		}

		public override void WriteToParcel (Parcel dest, ParcelableWriteFlags flags)
		{
			base.WriteToParcel (dest, flags);
			ParcelableHelper.WriteBoolean (dest, Answer);
		}
	}
}

