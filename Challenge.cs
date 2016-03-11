using System;
using System.Linq;
using System.Collections.Generic;

public class Challenge {

  public static string Question(int lowerBoundary, int upperBoundary, char op, int ansNo) {

    // Generating a random integer in the range giver.
    Random rnd = new Random();
    int correctAnswer = rnd.Next(lowerBoundary, upperBoundary);

    // Generate the required number of answers, including the correct one and
    // shuffling their order.
    List<int> answers = getAnswerList(lowerBoundary, upperBoundary, correctAnswer, ansNo);
    answers = shuffleAnswers(answers);

    // Get values for the variables x and y, which create the question i.e "x+y=?".
    string question = getXY(correctAnswer, lowerBoundary, upperBoundary, op);

    // Fully formulate the question and return it as a string.
    for (int i = 0; i < ansNo - 1; i++)
      question = question + answers.ElementAt(i) + ", ";
    question = question + answers.ElementAt(ansNo - 1);

    return question;
  }

  // Generate random answers.
  public static List<int> getAnswerList(int lowerBoundary, int upperBoundary, int correctAnswer, int ansNo){
    int random;
    Random rnd = new Random();
    List<int> ret = new List<int>();
    ret.Add(correctAnswer);
    for (int i = 0; i < ansNo - 1; i++){
      random = rnd.Next(lowerBoundary, upperBoundary);
      while (ret.Contains(random))
        random = rnd.Next(lowerBoundary, upperBoundary);
      ret.Add(random);
    }
    return ret;
  }

  // Randomly reorder the answer list.
  public static List<int> shuffleAnswers(List<int> answers){
    List<int> source = answers;
    Random rnd = new Random();
    answers = source.OrderBy(item => rnd.Next()).ToList();
    return answers;
  }

  // Set the values of the numbers whose sum will be required to calculate.
  public static string getXY(int correctAnswer, int lowerBoundary, int upperBoundary, char op){
    if (op.CompareTo('+') == 0){
      Random rnd = new Random();
      int x = rnd.Next(lowerBoundary, correctAnswer);
      int y = correctAnswer - x;
      return (x + " + " + y + "=?; ");
    }
    else return "The operator " + op + " is not supported. Try "+"";
  }

  public static void Main(){
    Console.WriteLine(Question (1, 10, '+', 4));
    Console.WriteLine(Question (10, 20, '+', 4));
    Console.WriteLine(Question (20, 100, '+', 4));
  }

}
