namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int player1Point;
        private int player2Point;

        private string player1Result = "";
        private string player2Result = "";

        public TennisGame2(string player1Name, string player2Name)
        {
            player1Point = 0;
        }

        public string GetScore()
        {
            var score = "";
            if (player1Point == player2Point && player1Point < 3)
            {
                if (player1Point == 0)
                    score = "Love";
                if (player1Point == 1)
                    score = "Fifteen";
                if (player1Point == 2)
                    score = "Thirty";
                score += "-All";
            }
            if (player1Point == player2Point && player1Point > 2)
                score = "Deuce";

            if (player1Point > 0 && player2Point == 0)
            {
                if (player1Point == 1)
                    player1Result = "Fifteen";
                if (player1Point == 2)
                    player1Result = "Thirty";
                if (player1Point == 3)
                    player1Result = "Forty";

                player2Result = "Love";
                score = player1Result + "-" + player2Result;
            }
            if (player2Point > 0 && player1Point == 0)
            {
                if (player2Point == 1)
                    player2Result = "Fifteen";
                if (player2Point == 2)
                    player2Result = "Thirty";
                if (player2Point == 3)
                    player2Result = "Forty";

                player1Result = "Love";
                score = player1Result + "-" + player2Result;
            }

            if (player1Point > player2Point && player1Point < 4)
            {
                if (player1Point == 2)
                    player1Result = "Thirty";
                if (player1Point == 3)
                    player1Result = "Forty";
                if (player2Point == 1)
                    player2Result = "Fifteen";
                if (player2Point == 2)
                    player2Result = "Thirty";
                score = player1Result + "-" + player2Result;
            }
            if (player2Point > player1Point && player2Point < 4)
            {
                if (player2Point == 2)
                    player2Result = "Thirty";
                if (player2Point == 3)
                    player2Result = "Forty";
                if (player1Point == 1)
                    player1Result = "Fifteen";
                if (player1Point == 2)
                    player1Result = "Thirty";
                score = player1Result + "-" + player2Result;
            }

            if (player1Point > player2Point && player2Point >= 3)
            {
                score = "Advantage player1";
            }

            if (player2Point > player1Point && player1Point >= 3)
            {
                score = "Advantage player2";
            }

            if (player1Point >= 4 && player2Point >= 0 && (player1Point - player2Point) >= 2)
            {
                score = "Win for player1";
            }
            if (player2Point >= 4 && player1Point >= 0 && (player2Point - player1Point) >= 2)
            {
                score = "Win for player2";
            }
            return score;
        }

        private void P1Score()
        {
            player1Point++;
        }

        private void P2Score()
        {
            player2Point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

    }
}

