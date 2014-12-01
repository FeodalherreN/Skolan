/* 
TestProgP1x.java
Testprogram för metoderna i Programmeringsuppgift 1, inklusieve extrauppgifter
Rolf Axelsson
*/
import javax.swing.*;

public class TestProgP1x {
    public void exerciseX1(Prog1 prog1) {
        System.out.println("TEST AV: sum");
         prog1.sum(1827);
        prog1.sum(2005);
        System.out.println();
    }
    
    public void exerciseX2(Prog1 prog1) {
        System.out.println("TEST AV: sumN");
        prog1.sumN(20,100,210);
        prog1.sumN(7,1,100);
       prog1.sumN(7,100,1);
       System.out.println();
    }
    
    public void exerciseX3(Prog1 prog1) {
        System.out.println("TEST AV: factorial");
        prog1.factorial(4);
        prog1.factorial(7);
        System.out.println();
    }
        
    public void programLoop() {
        Prog1 prog1 = new Prog1();
        TestProgP1 tp1 = new TestProgP1();
        String menu = "Välj den metod som ska anropas:\n\n" + 
                "  1. price\n" +
                "  2. date\n" +
                "  3. odd\n" +
                "  4. positiveNegative\n" +
                "  5. series7\n" +
                "  6. multiplicationTable\n" +
                "  7. balance\n" +
                "-------------------------\n" +
                "  8. sum\n" +
                "  9. sumN\n" +
                " 10. factorial\n" +
                "-------------------------\n" +
                "  0. Avsluta programmet\n\n" +
                "Ange ditt val";
        int choice = Integer.parseInt( JOptionPane.showInputDialog( menu ) );
        while(choice!=0) {
            switch(choice) {
                case 1 : tp1.exerciceA(prog1); break;
                case 2 : tp1.exerciceB(prog1); break;
                case 3 : tp1.exerciceC(prog1); break;
                case 4 : tp1.exerciceD(prog1); break;
                case 5 : tp1.exerciceE(prog1); break;
                case 6 : tp1.exerciceF(prog1); break;
                case 7 : tp1.exerciceG(prog1); break;
                case 8 : exerciseX1(prog1); break;
                case 9 : exerciseX2(prog1); break;
                case 10: exerciseX3(prog1); break;
            }
            choice = Integer.parseInt( JOptionPane.showInputDialog( menu ) );
        }
    }
    
    public static void main(String[] args) {
        TestProgP1x prog = new TestProgP1x();
        prog.programLoop();
    }
}
