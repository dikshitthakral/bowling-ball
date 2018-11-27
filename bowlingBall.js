// balls input 
let balls = [[10],[9,1],[5,5],[7,2],[10],[10],[10],[9,0],[8,2],[9,1,10]];

/**
 * Bowling Ball Score
 * @function
 * @param {*} balls 
 * return total Score
 */
var bowlingBallScore = function(balls) {
    let totalScore =0;
    for(let i =0; i< balls.length; i++) {
        totalScore = bowlingScore(i, balls, totalScore);
        console.log(totalScore);
    }
    return totalScore;
}

let bowlingScore = function(i, balls, totalScore) {
    let currentScore = strikeSpareScores(balls[i]);
    if(i < balls.length-1 && currentScore.strike === true) {
        let nextBallScore = strikeSpareScores(balls[i+1]);
        if(nextBallScore.strike === true && i+1 < balls.length -1 ) {
            totalScore = totalScore + currentScore.score + nextBallScore.score + balls[i+2][0];
        }
        else {
            totalScore = totalScore + currentScore.score + nextBallScore.score;
        }
        
    }
    else if(i < balls.length-1 && currentScore.spare === true) {
        totalScore = totalScore + currentScore.score + balls[i+1][0];
    }
    else {
        totalScore = totalScore + currentScore.score;
    }
    return totalScore;
}

let strikeSpareScores = function(ball) {
    let score =0,
        strike = false,
        spare= false;

    for(let i=0;i< ball.length;i++) {
        score = score + ball[i];
        if(ball[0] === 10) {
            strike = true;
        }
        if(score >= 10) {
            spare = true;
        }
    }
    return {score,strike, spare};
}

let score = bowlingBallScore(balls);
