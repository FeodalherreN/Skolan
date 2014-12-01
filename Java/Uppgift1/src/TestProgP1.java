/* 
TestProgP1.java
Testprogram för metoderna i Programmeringsuppgift 1
Rolf Axelsson
*/
import javax.swing.*;

public class TestProgP1 {
    public void exerciceA(Prog1 prog1) {
        System.out.println("TEST AV: price");
        prog1.price();
        System.out.println();
    }
    
    public void exerciceB(Prog1 prog1) {
        System.out.println("TEST AV: date");
        prog1.date();
        System.out.println();
    }
    
    public void exerciceC(Prog1 prog1) {
        System.out.println("TEST AV: odd");
        prog1.odd();
        System.out.println();
    }
    
    public void exerciceD(Prog1 prog1) {
        System.out.println("TEST AV: positiveNegative");
        prog1.positiveNegative();
        System.out.println();
    }
    
    public void exerciceE(Prog1 prog1) {
        System.out.println("TEST AV: series7");
        prog1.series7(26, 112);
        prog1.series7(11, 25);
        System.out.println();
    }
    
    public void exerciceF(Prog1 prog1) {
        System.out.println("TEST AV: table");
        prog1.table(13,8,12);
        prog1.table(5,10,18);
        System.out.println();
    }
    
    public void exerciceG(Prog1 prog1) {
        System.out.println("TEST AV: balance");
        prog1.balance(1000, 0.04, 9);
        System.out.println();
       prog1.balance(10000, 0.08, 12);
        System.out.println();
    }
        
    public void programLoop() {
        Prog1 prog1 = new Prog1();
        String menu = "Välj den metod som ska anropas:\n\n" + 
                "1. price\n" +
                "2. date\n" +
                "3. odd\n" +
                "4. positiveNegative\n" +
                "5. series7\n" +
                "6. multiplicationTable\n" +
                "7. balance\n" +
                "0. Avsluta programmet\n\n" +
                "Ange ditt val";
        int choice = Integer.parseInt( JOptionPane.showInputDialog( menu ) );
        while(choice!=0) {
            switch(choice) {
                case 1 : exerciceA(prog1); break;
                case 2 : exerciceB(prog1); break;
                case 3 : exerciceC(prog1); break;
                case 4 : exerciceD(prog1); break;
                case 5 : exerciceE(prog1); break;
                case 6 : exerciceF(prog1); break;
                case 7 : exerciceG(prog1); break;
            }
            choice = Integer.parseInt( JOptionPane.showInputDialog( menu ) );
        }
    }
    
    public static void main(String[] args) {
        TestProgP1 prog = new TestProgP1();
        prog.programLoop();
    }
}
