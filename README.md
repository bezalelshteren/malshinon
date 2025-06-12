# 🔎 MALSHINON Project

מערכת לדיווח, ניהול ומעקב אחר אנשים ודיווחים חשאיים.

---

## ✍️ תקציר

"MALSHINON" היא מערכת מודולרית בשפת #C, עם גישה למסד נתונים מסוג MySQL, המאפשרת:

* ✉️ הוספת אנשים (מלשינים/יעדים)
* 📝 שליחת דיווחים בין אנשים
* 📈 ניתוח נתוני דיווחים
* 🔐 שימוש בקוד סודי מוצפן

---

## ⚙️ מבנה הפרויקט

```bash
MALSHINON/
├── Program.cs            # נקודת הכניסה הראשית
├── menu.cs               # ממשק משתמש בסיסי (Console Menu)
├── persons.cs            # הגדרת מחלקת אדם (מלשין/יעד)
├── report.cs             # הגדרת מחלקת דיווח
├── dhl.cs                # לוגיקה לעבודה עם מסד נתונים
├── malshinonOptions.cs   # פעולות עיקריות של המערכתSavable.cs      
```

---

## 🛠️ תכונות עיקריות

* ✍️ **הכנסת אדם חדש**:

  * נבדק אם קיים לפי שם מלא
  * אם לא, נוצר קוד סודי מוצפן

* 🔍 **חיפוש לפי שם או קוד סודי**:

  * חיפוש מדויק בטבלה לפי `firstName + lastName` או `secretCode`

* 📝 **שליחת דיווח**:

  * הכנסת טקסט, זיהוי המדווח והיעד
  * שמירה בטבלת `intelreports`

* 💡 **עדכון מונים**:(עדיין לא עובד אבל קיים)

  * העלאת `numReports` ו־`numMentions`

---

## 📁 מסד נתונים (MySQL)

### טבלת people:

```sql
CREATE TABLE people (
  id INT AUTO_INCREMENT PRIMARY KEY,
  firstName VARCHAR(50),
  lastName VARCHAR(50),
  secretCode VARCHAR(100) UNIQUE,
  type VARCHAR(30),
  numReports INT DEFAULT 0,
  numMentions INT DEFAULT 0
);
```

### טבלת intelreports:

```sql
CREATE TABLE intelreports (
  id INT AUTO_INCREMENT PRIMARY KEY,
  reporterId INT,
  targetId INT,
  text TEXT,
  FOREIGN KEY (reporterId) REFERENCES people(id),
  FOREIGN KEY (targetId) REFERENCES people(id)
);
```

---

## 📑 עקרונות הקוד

* ✅ שימוש ב־**Object-Oriented Programming**
* ✅ שמירה על עקרונות **SOLID** בהדרגה
* ✅ מבנה מודולרי להרחבה עתידית
* ✅ אפשרות לשימוש ב־**Reflection + Generics** לשמירה גמישה

---

## 📢 להרצה:

1. פתח את הפרויקט ב־Visual Studio
2. הגדר את `Program.cs` כ־Startup Project
3. ודא שחיבור למסד הנתונים פעיל
4. הרץ 👇

---

---

❤️ בהצלחה במעקב אחרי המלשינים!
