﻿-- Capture your answer here for each "Test It With SQL" section of this assignment
    -- write each as comments


--Part 1: List the columns and their data types in the Jobs table.

/*
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_SCHEMA = 'techjobs' AND TABLE_NAME = 'jobs';
/*

--Part 2: Write a query to list the names of the employers in St. Louis City.

/*
SELECT Name
FROM techjobs.employers
WHERE Location = 'St. Louis City';
/*

--Part 3: Write a query to return a list of the names and descriptions of all skills that are attached to jobs in alphabetical order.
    --If a skill does not have a job listed, it should not be included in the results of this query.

/*
SELECT DISTINCT SkillName
FROM techjobs.skills s
JOIN techjobs.jobskills js ON s.Id = js.SkillsId
JOIN techjobs.jobs j ON js.JobsId = j.Id
ORDER BY SkillName;
/*