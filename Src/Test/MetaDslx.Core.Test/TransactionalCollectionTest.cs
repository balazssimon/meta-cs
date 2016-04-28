using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MetaDslx.Core.Immutable;
using MetaDslx.Core.Collections.Transactional;

namespace MetaDslx.Core.Test
{
    [TestClass]
    public class TransactionalHashSetTest
    {
        [TestMethod]
        public void TestHashSetAddCommit()
        {
            TxHashSet<string> names = new TxHashSet<string>();
            names.Add("Alice");
            using (CollectionTxScope scope = new CollectionTxScope())
            {
                names.Add("Bob");
                scope.Commit();
            }
            names.Add("Cecil");
            Assert.AreEqual(3, names.Count);
            Assert.IsTrue(names.Contains("Alice"));
            Assert.IsTrue(names.Contains("Bob"));
            Assert.IsTrue(names.Contains("Cecil"));
        }
        [TestMethod]
        public void TestHashSetRemoveCommit()
        {
            TxHashSet<string> names = new TxHashSet<string>();
            names.Add("Alice");
            names.Add("Bob");
            names.Add("Cecil");
            Assert.IsTrue(names.Contains("Alice"));
            Assert.IsTrue(names.Contains("Bob"));
            Assert.IsTrue(names.Contains("Cecil"));
            using (CollectionTxScope scope = new CollectionTxScope())
            {
                names.Remove("Bob");
                scope.Commit();
            }
            Assert.AreEqual(2, names.Count);
            Assert.IsTrue(names.Contains("Alice"));
            Assert.IsFalse(names.Contains("Bob"));
            Assert.IsTrue(names.Contains("Cecil"));
        }
        [TestMethod]
        public void TestHashSetAddRollback()
        {
            TxHashSet<string> names = new TxHashSet<string>();
            names.Add("Alice");
            try
            {
                using (CollectionTxScope scope = new CollectionTxScope())
                {
                    names.Add("Bob");
                    throw new Exception();
                    //scope.Commit();
                }
            }
            catch (Exception)
            {
                // nop
            }
            names.Add("Cecil");
            Assert.AreEqual(2, names.Count);
            Assert.IsTrue(names.Contains("Alice"));
            Assert.IsFalse(names.Contains("Bob"));
            Assert.IsTrue(names.Contains("Cecil"));
        }
        [TestMethod]
        public void TestHashSetRemoveRollback()
        {
            TxHashSet<string> names = new TxHashSet<string>();
            names.Add("Alice");
            names.Add("Bob");
            names.Add("Cecil");
            Assert.IsTrue(names.Contains("Alice"));
            Assert.IsTrue(names.Contains("Bob"));
            Assert.IsTrue(names.Contains("Cecil"));
            try
            {
                using (CollectionTxScope scope = new CollectionTxScope())
                {
                    names.Remove("Bob");
                    throw new Exception();
                    //scope.Commit();
                }
            }
            catch (Exception)
            {
                // nop
            }
            Assert.AreEqual(3, names.Count);
            Assert.IsTrue(names.Contains("Alice"));
            Assert.IsTrue(names.Contains("Bob"));
            Assert.IsTrue(names.Contains("Cecil"));
        }
        [TestMethod]
        public void TestHashSetClearCommit()
        {
            TxHashSet<string> names = new TxHashSet<string>();
            names.Add("Alice");
            using (CollectionTxScope scope = new CollectionTxScope())
            {
                names.Add("Bob");
                names.Clear();
                scope.Commit();
            }
            names.Add("Cecil");
            Assert.AreEqual(1, names.Count);
            Assert.IsFalse(names.Contains("Alice"));
            Assert.IsFalse(names.Contains("Bob"));
            Assert.IsTrue(names.Contains("Cecil"));
        }
        [TestMethod]
        public void TestHashSetClearRollback()
        {
            TxHashSet<string> names = new TxHashSet<string>();
            names.Add("Alice");
            try
            {
                using (CollectionTxScope scope = new CollectionTxScope())
                {
                    names.Add("Bob");
                    names.Clear();
                    throw new Exception();
                    //scope.Commit();
                }
            }
            catch (Exception)
            {
                // nop
            }
            names.Add("Cecil");
            Assert.AreEqual(2, names.Count);
            Assert.IsTrue(names.Contains("Alice"));
            Assert.IsFalse(names.Contains("Bob"));
            Assert.IsTrue(names.Contains("Cecil"));
        }
    }

    [TestClass]
    public class TransactionalListTest
    {
        [TestMethod]
        public void TestListAddCommit()
        {
            TxList<string> names = new TxList<string>();
            names.Add("Alice");
            using (CollectionTxScope scope = new CollectionTxScope())
            {
                names.Add("Bob");
                scope.Commit();
            }
            names.Add("Cecil");
            Assert.AreEqual(3, names.Count);
            Assert.IsTrue(names.Contains("Alice"));
            Assert.IsTrue(names.Contains("Bob"));
            Assert.IsTrue(names.Contains("Cecil"));
        }
        [TestMethod]
        public void TestListRemoveCommit()
        {
            TxList<string> names = new TxList<string>();
            names.Add("Alice");
            names.Add("Bob");
            names.Add("Cecil");
            Assert.IsTrue(names.Contains("Alice"));
            Assert.IsTrue(names.Contains("Bob"));
            Assert.IsTrue(names.Contains("Cecil"));
            using (CollectionTxScope scope = new CollectionTxScope())
            {
                names.Remove("Bob");
                scope.Commit();
            }
            Assert.AreEqual(2, names.Count);
            Assert.IsTrue(names.Contains("Alice"));
            Assert.IsFalse(names.Contains("Bob"));
            Assert.IsTrue(names.Contains("Cecil"));
        }
        [TestMethod]
        public void TestListAddRollback()
        {
            TxList<string> names = new TxList<string>();
            names.Add("Alice");
            try
            {
                using (CollectionTxScope scope = new CollectionTxScope())
                {
                    names.Add("Bob");
                    throw new Exception();
                    //scope.Commit();
                }
            }
            catch (Exception)
            {
                // nop
            }
            names.Add("Cecil");
            Assert.AreEqual(2, names.Count);
            Assert.IsTrue(names.Contains("Alice"));
            Assert.IsFalse(names.Contains("Bob"));
            Assert.IsTrue(names.Contains("Cecil"));
        }
        [TestMethod]
        public void TestListRemoveRollback()
        {
            TxList<string> names = new TxList<string>();
            names.Add("Alice");
            names.Add("Bob");
            names.Add("Cecil");
            Assert.IsTrue(names.Contains("Alice"));
            Assert.IsTrue(names.Contains("Bob"));
            Assert.IsTrue(names.Contains("Cecil"));
            try
            {
                using (CollectionTxScope scope = new CollectionTxScope())
                {
                    names.Remove("Bob");
                    throw new Exception();
                    //scope.Commit();
                }
            }
            catch (Exception)
            {
                // nop
            }
            Assert.AreEqual(3, names.Count);
            Assert.IsTrue(names.Contains("Alice"));
            Assert.IsTrue(names.Contains("Bob"));
            Assert.IsTrue(names.Contains("Cecil"));
        }
        [TestMethod]
        public void TestListClearCommit()
        {
            TxList<string> names = new TxList<string>();
            names.Add("Alice");
            using (CollectionTxScope scope = new CollectionTxScope())
            {
                names.Add("Bob");
                names.Clear();
                scope.Commit();
            }
            names.Add("Cecil");
            Assert.AreEqual(1, names.Count);
            Assert.IsFalse(names.Contains("Alice"));
            Assert.IsFalse(names.Contains("Bob"));
            Assert.IsTrue(names.Contains("Cecil"));
        }
        [TestMethod]
        public void TestListClearRollback()
        {
            TxList<string> names = new TxList<string>();
            names.Add("Alice");
            try
            {
                using (CollectionTxScope scope = new CollectionTxScope())
                {
                    names.Add("Bob");
                    names.Clear();
                    throw new Exception();
                    //scope.Commit();
                }
            }
            catch (Exception)
            {
                // nop
            }
            names.Add("Cecil");
            Assert.AreEqual(2, names.Count);
            Assert.IsTrue(names.Contains("Alice"));
            Assert.IsFalse(names.Contains("Bob"));
            Assert.IsTrue(names.Contains("Cecil"));
        }
        [TestMethod]
        public void TestListIndexCommit()
        {
            TxList<string> names = new TxList<string>();
            names.Add("Alice");
            using (CollectionTxScope scope = new CollectionTxScope())
            {
                names.Add("Bob");
                names[0] = "Doug";
                scope.Commit();
            }
            names.Add("Cecil");
            Assert.AreEqual(3, names.Count);
            Assert.AreEqual("Doug", names[0]);
            Assert.AreEqual("Bob", names[1]);
            Assert.AreEqual("Cecil", names[2]);
        }
        [TestMethod]
        public void TestListIndexRollback()
        {
            TxList<string> names = new TxList<string>();
            names.Add("Alice");
            try
            {
                using (CollectionTxScope scope = new CollectionTxScope())
                {
                    names.Add("Bob");
                    names[0] = "Doug";
                    throw new Exception();
                    //scope.Commit();
                }
            }
            catch (Exception)
            {
                // nop
            }
            names.Add("Cecil");
            Assert.AreEqual(2, names.Count);
            Assert.AreEqual("Alice", names[0]);
            Assert.AreEqual("Cecil", names[1]);
        }
        [TestMethod]
        public void TestListInsertCommit()
        {
            TxList<string> names = new TxList<string>();
            names.Add("Alice");
            using (CollectionTxScope scope = new CollectionTxScope())
            {
                names.Add("Bob");
                names.Insert(1, "Doug");
                scope.Commit();
            }
            names.Add("Cecil");
            Assert.AreEqual(4, names.Count);
            Assert.AreEqual("Alice", names[0]);
            Assert.AreEqual("Doug", names[1]);
            Assert.AreEqual("Bob", names[2]);
            Assert.AreEqual("Cecil", names[3]);
        }
        [TestMethod]
        public void TestListInsertRollback()
        {
            TxList<string> names = new TxList<string>();
            names.Add("Alice");
            try
            {
                using (CollectionTxScope scope = new CollectionTxScope())
                {
                    names.Add("Bob");
                    names.Insert(1, "Doug");
                    throw new Exception();
                    //scope.Commit();
                }
            }
            catch (Exception)
            {
                // nop
            }
            names.Add("Cecil");
            Assert.AreEqual(2, names.Count);
            Assert.AreEqual("Alice", names[0]);
            Assert.AreEqual("Cecil", names[1]);
        }
        [TestMethod]
        public void TestListRemoveAtCommit()
        {
            TxList<string> names = new TxList<string>();
            names.Add("Alice");
            using (CollectionTxScope scope = new CollectionTxScope())
            {
                names.Add("Bob");
                names.RemoveAt(0);
                scope.Commit();
            }
            names.Add("Cecil");
            Assert.AreEqual(2, names.Count);
            Assert.AreEqual("Bob", names[0]);
            Assert.AreEqual("Cecil", names[1]);
        }
        [TestMethod]
        public void TestListRemoveAtRollback()
        {
            TxList<string> names = new TxList<string>();
            names.Add("Alice");
            try
            {
                using (CollectionTxScope scope = new CollectionTxScope())
                {
                    names.Add("Bob");
                    names.RemoveAt(0);
                    throw new Exception();
                    //scope.Commit();
                }
            }
            catch (Exception)
            {
                // nop
            }
            names.Add("Cecil");
            Assert.AreEqual(2, names.Count);
            Assert.AreEqual("Alice", names[0]);
            Assert.AreEqual("Cecil", names[1]);
        }
    }

    [TestClass]
    public class TransactionalDictionaryTest
    {
        [TestMethod]
        public void TestDictionaryAddCommit()
        {
            TxDictionary<string, int> names = new TxDictionary<string, int>();
            names.Add("Alice", 10);
            using (CollectionTxScope scope = new CollectionTxScope())
            {
                names.Add("Bob", 20);
                scope.Commit();
            }
            names.Add("Cecil", 30);
            Assert.AreEqual(3, names.Count);
            Assert.IsTrue(names.ContainsKey("Alice"));
            Assert.IsTrue(names.ContainsKey("Bob"));
            Assert.IsTrue(names.ContainsKey("Cecil"));
            Assert.AreEqual(10, names["Alice"]);
            Assert.AreEqual(20, names["Bob"]);
            Assert.AreEqual(30, names["Cecil"]);
        }
        [TestMethod]
        public void TestDictionaryRemoveCommit()
        {
            TxDictionary<string, int> names = new TxDictionary<string, int>();
            names.Add("Alice", 10);
            names.Add("Bob", 20);
            names.Add("Cecil", 30);
            Assert.AreEqual(3, names.Count);
            Assert.IsTrue(names.ContainsKey("Alice"));
            Assert.IsTrue(names.ContainsKey("Bob"));
            Assert.IsTrue(names.ContainsKey("Cecil"));
            Assert.AreEqual(10, names["Alice"]);
            Assert.AreEqual(20, names["Bob"]);
            Assert.AreEqual(30, names["Cecil"]);
            using (CollectionTxScope scope = new CollectionTxScope())
            {
                names.Remove("Bob");
                scope.Commit();
            }
            Assert.AreEqual(2, names.Count);
            Assert.IsTrue(names.ContainsKey("Alice"));
            Assert.IsFalse(names.ContainsKey("Bob"));
            Assert.IsTrue(names.ContainsKey("Cecil"));
            Assert.AreEqual(10, names["Alice"]);
            Assert.AreEqual(30, names["Cecil"]);
        }
        [TestMethod]
        public void TestDictionaryAddRollback()
        {
            TxDictionary<string, int> names = new TxDictionary<string, int>();
            names.Add("Alice", 10);
            try
            {
                using (CollectionTxScope scope = new CollectionTxScope())
                {
                    names.Add("Bob", 20);
                    throw new Exception();
                    //scope.Commit();
                }
            }
            catch (Exception)
            {
                // nop
            }
            names.Add("Cecil", 30);
            Assert.AreEqual(2, names.Count);
            Assert.IsTrue(names.ContainsKey("Alice"));
            Assert.IsFalse(names.ContainsKey("Bob"));
            Assert.IsTrue(names.ContainsKey("Cecil"));
            Assert.AreEqual(10, names["Alice"]);
            Assert.AreEqual(30, names["Cecil"]);
        }
        [TestMethod]
        public void TestDictionaryRemoveRollback()
        {
            TxDictionary<string, int> names = new TxDictionary<string, int>();
            names.Add("Alice", 10);
            names.Add("Bob", 20);
            names.Add("Cecil", 30);
            Assert.AreEqual(3, names.Count);
            Assert.IsTrue(names.ContainsKey("Alice"));
            Assert.IsTrue(names.ContainsKey("Bob"));
            Assert.IsTrue(names.ContainsKey("Cecil"));
            Assert.AreEqual(10, names["Alice"]);
            Assert.AreEqual(20, names["Bob"]);
            Assert.AreEqual(30, names["Cecil"]);
            try
            {
                using (CollectionTxScope scope = new CollectionTxScope())
                {
                    names.Remove("Bob");
                    throw new Exception();
                    //scope.Commit();
                }
            }
            catch (Exception)
            {
                // nop
            }
            Assert.AreEqual(3, names.Count);
            Assert.IsTrue(names.ContainsKey("Alice"));
            Assert.IsTrue(names.ContainsKey("Bob"));
            Assert.IsTrue(names.ContainsKey("Cecil"));
            Assert.AreEqual(10, names["Alice"]);
            Assert.AreEqual(20, names["Bob"]);
            Assert.AreEqual(30, names["Cecil"]);
        }
        [TestMethod]
        public void TestDictionaryClearCommit()
        {
            TxDictionary<string, int> names = new TxDictionary<string, int>();
            names.Add("Alice", 10);
            using (CollectionTxScope scope = new CollectionTxScope())
            {
                names.Add("Bob", 20);
                names.Clear();
                scope.Commit();
            }
            names.Add("Cecil", 30);
            Assert.AreEqual(1, names.Count);
            Assert.IsFalse(names.ContainsKey("Alice"));
            Assert.IsFalse(names.ContainsKey("Bob"));
            Assert.IsTrue(names.ContainsKey("Cecil"));
            Assert.AreEqual(30, names["Cecil"]);
        }
        [TestMethod]
        public void TestDictionaryClearRollback()
        {
            TxDictionary<string, int> names = new TxDictionary<string, int>();
            names.Add("Alice", 10);
            try
            {
                using (CollectionTxScope scope = new CollectionTxScope())
                {
                    names.Add("Bob", 20);
                    names.Clear();
                    throw new Exception();
                    //scope.Commit();
                }
            }
            catch (Exception)
            {
                // nop
            }
            names.Add("Cecil", 30);
            Assert.AreEqual(2, names.Count);
            Assert.IsTrue(names.ContainsKey("Alice"));
            Assert.IsFalse(names.ContainsKey("Bob"));
            Assert.IsTrue(names.ContainsKey("Cecil"));
            Assert.AreEqual(10, names["Alice"]);
            Assert.AreEqual(30, names["Cecil"]);
        }
        [TestMethod]
        public void TestDictionaryIndexCommit()
        {
            TxDictionary<string, int> names = new TxDictionary<string, int>();
            names.Add("Alice", 10);
            using (CollectionTxScope scope = new CollectionTxScope())
            {
                names.Add("Bob", 20);
                names["Alice"] = 50;
                scope.Commit();
            }
            names.Add("Cecil", 30);
            Assert.AreEqual(3, names.Count);
            Assert.IsTrue(names.ContainsKey("Alice"));
            Assert.IsTrue(names.ContainsKey("Bob"));
            Assert.IsTrue(names.ContainsKey("Cecil"));
            Assert.AreEqual(50, names["Alice"]);
            Assert.AreEqual(20, names["Bob"]);
            Assert.AreEqual(30, names["Cecil"]);
        }
        [TestMethod]
        public void TestDictionaryIndexRollback()
        {
            TxDictionary<string, int> names = new TxDictionary<string, int>();
            names.Add("Alice", 10);
            try
            {
                using (CollectionTxScope scope = new CollectionTxScope())
                {
                    names.Add("Bob", 20);
                    names["Alice"] = 50;
                    throw new Exception();
                    //scope.Commit();
                }
            }
            catch (Exception)
            {
                // nop
            }
            names.Add("Cecil", 30);
            Assert.AreEqual(2, names.Count);
            Assert.IsTrue(names.ContainsKey("Alice"));
            Assert.IsFalse(names.ContainsKey("Bob"));
            Assert.IsTrue(names.ContainsKey("Cecil"));
            Assert.AreEqual(10, names["Alice"]);
            Assert.AreEqual(30, names["Cecil"]);
        }
    }

}
