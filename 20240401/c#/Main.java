
//import org.apache.commons.lang3.time.StopWatch;
//import org.w3c.dom.stylesheets.LinkStyle;

import java.util.ArrayList;
import java.util.List;

public class Main {
    public static void main(String[] args) {
//        org.apache.commons.lang3.time.StopWatch sw = (StopWatch) StopWatch.create();

//        while (true) {
//            sw.start();
//            StringBuilder sb = new StringBuilder();
//            long t1 = sw.getTime();
//            for (int i = 0; i < Integer.MAX_VALUE / 50; i++) {
//                sb.append(i);
//                sb.append("Hello");
//            }
//            long t2 = sw.getTime();
//            sw.reset();
//            System.out.println(t2 - t1);
//        }

        long startTime, endTime;
        Integer count = Integer.valueOf(args == null || args.length == 0 ? "10000000" : args[0]);
        System.out.println(count);
        startTime = System.currentTimeMillis();
        List<StringBuffer> list = new ArrayList<>();
        for (int i = 0; i < count; i++) {
            StringBuffer str = new StringBuffer();
            //StringBuilder str=new StringBuilder();
            str.append("hellow world." + i);
            list.add(str);
        }
//        for (StringBuffer stringBuffer : list) {
//            stringBuffer.toString();
//        }
        endTime = System.currentTimeMillis();
        System.out.println(endTime - startTime);


    }
}