namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;



        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            string score = "";

            if (m_score1 == m_score2)
            {
                score = GetForEvenScore(m_score1);
            }
            else if (m_score1 >= 4 || m_score2 >= 4)
            {
                score = GetAdvantageOrWinScore();
            }
            else
            {
                score = GetScoreForUnderFour();
            }
            return score;
        }

        private string GetScoreForUnderFour()
        {
            string score = "";
            var tempScore = 0;
            for (var i = 1; i < 3; i++)
            {
                if (i == 1) tempScore = m_score1;
                else { score += "-"; tempScore = m_score2; }

                 score += ScoreForUnderFourTerms(tempScore);

            }
            return score;

        }

        private string GetAdvantageOrWinScore()
        {
            var minusResult = m_score1 - m_score2;
            return GetAdvantageOrWinScoreTerms(minusResult);
        }


        private string GetForEvenScore(int points) => points switch
        {
            0 => "Love-All",
            1 => "Fifteen-All",
            2 => "Thirty-All",
            _ => "Deuce"
        };
        private string GetAdvantageOrWinScoreTerms(int resultDifference) => resultDifference switch
        {
            1 => "Advantage player1",
            -1 => "Advantage player2",
            >= 2 => "Win for player1",
            _ => "Win for player2"
        };


        private string ScoreForUnderFourTerms(int tempScore) => tempScore switch
        {
            0 => "Love",
            1 => "Fifteen",
            2 => "Thirty",
            3 => "Forty",
            _ => ""
        };
    }
}

