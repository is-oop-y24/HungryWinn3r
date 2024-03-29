﻿using NUnit.Framework;

namespace Backups.Tests
{
    public class BackupsTests
    {
        private SimpleAlgorithmFactory factory;

        [SetUp]
        public void Setup()
        {
            factory = new SimpleAlgorithmFactory(new TestRepository());
        }

        [Test]
        public void AddTwoJobs_Run_DeleteOneJob_Run_ResultTwoRestorePointsAndThreeStorages()
        {
            Algorithm algorithm = factory.CreateAlgorithm(AlgorithmType.SPLIT);
            var backup = new BackupJob("Backup1", algorithm, 10);
            backup.AddFile(@"C:\MyVideo\video1.txt");
            backup.AddFile(@"C:\MyPhoto\photo1.txt");
            backup.Backup();
            backup.DeleteFile(@"C:\MyPhoto\photo1.txt");
            backup.Backup();

            int expectedRestorePoints = 2;
            int expectedStorage = 3;

            Assert.AreEqual(expectedRestorePoints, backup.RestorePoints.Count);
            Assert.AreEqual(expectedStorage, backup.CountStorages());
        }

        [Test]
        public void ChooseSingleStorageAlgorithm_AddTwoJobs_Run_DeleteOneJob_Run_ResultTwoRestorePointAndTwoStorage()
        {
            Algorithm algorithm = factory.CreateAlgorithm(AlgorithmType.SINGLE);
            var backup = new BackupJob("Backup2", algorithm, 10);
            backup.AddFile(@"C:\MyVideo\video1.txt");
            backup.AddFile(@"C:\MyPhoto\photo1.txt");
            backup.Backup();
            backup.DeleteFile(@"C:\MyPhoto\photo1.txt");
            backup.Backup();

            int expectedRestorePoints = 2;
            int expectedStorage = 2;

            Assert.AreEqual(expectedRestorePoints, backup.RestorePoints.Count);
            Assert.AreEqual(expectedStorage, backup.CountStorages());
        }
    }
}
