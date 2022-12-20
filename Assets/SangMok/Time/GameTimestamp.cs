using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameTimestamp
{
    public int year;
    public enum Season 
    {
        Spring,
        Summer,
        Fall,
        Winter
    }
    public Season season;

    public enum DayOfTheWeek
    {
        Saturday,
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday
        
    }
    public int day;
    public int hour;
    public int minute;

   
    public GameTimestamp(int year, Season season, int day, int hour, int minute)
    {
        this.year = year;
        this.season = season;
        this.day = day;
        this.hour = hour;
        this.minute = minute;
    }

    //시간을 1분씩 증가시키는 함수
    public void UpdateClock()
    {
        minute++;
        //1시간에 60분
        if (minute >= 60)
        {
            //분 재설정
            minute = 0;
            hour++;
        }
        //하루에 24시간
        if (hour >= 24)
        {
            //시간 재설정
            hour = 0;
            day++;
        }
        //계절은 30일 주기로 돈다
        if (day > 30)
        {
            //일 재설정
            day = 1;
            
            //마지막 계절(겨울)이면 재설정하고 봄으로 변경
            if (season == Season.Winter)
            {
                season = Season.Spring;
                //연도 증가
                year++;
            }
            else
            {
                //계절 증가(봄->여름->가을->겨울)
                season++;
            }
        }
    }

    public DayOfTheWeek GetDayOfTheWeek()
    {
        //경과된 총 시간을 일로 변환
        int daysPassed = YearsToDays(year) + SeasonsToDays(season) + day;
        //일수를 나눈 나머지 7이 경과됨
        int dayIndex = daysPassed % 7;
        //요일로 전송
        return (DayOfTheWeek)dayIndex;

    }
    //시간을 분으로 변환 (1시간 = 60분)
    public static int HoursToMinutes(int hour)
    {
        //60분 = 1시간
        return hour * 60;
    }
    //일을 시간으로 변환 (1일 = 24시간)
    public static int DaysToHours(int days)
    {
        //24시간 = 1일
        return days * 24;
    }
    //계절을 일로 변환 (1계절 = 30일)
    public static int SeasonsToDays(Season season)
    {
        //30일 = 1계절
        return (int)season * 30;
    }
    //몇 년에서 며칠
    public static int YearsToDays(int years)
    {
        return years * 4 * 30;
    }
    
    
}

