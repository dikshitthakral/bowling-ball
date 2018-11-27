using System;
using System.Dynamic;

public class Test
{
	public static void Main()
	{
		// your code goes here
		int totalScore =0;
        // input for game
		int[][] balls = {
			new int[] { 10 },
    		new int[] { 9,1 },
    		new int[] { 5, 5 },
    		new int[] { 7, 2 },
    		new int[] { 10 },
    		new int[] { 10 },
    		new int[] { 10 },
    		new int[] { 9, 0 },
    		new int[] { 8, 2 },
    		new int[] { 9, 1, 10 }
		};
		Test t = new Test();
    	for(int i =0; i< balls.Length; i++) {
        	totalScore = t.BowlingScore(i, balls, totalScore);
        	Console.WriteLine(totalScore);
    	}
	}
	
    //return the total score for the ball user hit
	public int BowlingScore(int i, int[][] balls, int totalScore)
	{
		Test t = new Test();
    	dynamic currentScore = t.StrikeSpareScores(balls[i]);
    	if(i < balls.Length-1 && currentScore.strike == true) {
        	dynamic nextBallScore = t.StrikeSpareScores(balls[i+1]);
			
        	if(nextBallScore.strike == true && i+1 < (balls.Length -1) ) {
            	totalScore = totalScore + currentScore.score + nextBallScore.score + balls[i+2][0];
        	}
        	else {
            	totalScore = totalScore + currentScore.score + nextBallScore.score;
        	}
    	}
    	else if(i < balls.Length-1 && currentScore.spare == true) {
        	totalScore = totalScore + currentScore.score + balls[i+1][0];
		}
    	else {
        	totalScore = totalScore + currentScore.score;
    	}
    	return totalScore;
	}
	
    // returns an object having score for that ball, user has done strike or spare
	public object StrikeSpareScores(int[] ball)
	{
    	int score =0;
        bool strike = false;
        bool spare= false;

    	for(int i=0;i< ball.Length;i++) {
        	score = score + ball[i];
        	if(ball[0] == 10) {
            	strike = true;
        	}
        	if(score >= 10) {
            	spare = true;
        	}
    	}
    	dynamic result = new ExpandoObject();
    	result.score = score;
    	result.strike = strike;
    	result.spare = spare;
    	return result;
	}
}