using MetaDslx.CodeAnalysis.Meta.Test.Languages.PropertiesTest;
using MetaDslx.Modeling;
using MetaDslx.Tests;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Meta.Test
{
    public class AssociationTest : DebugAssertUnitTest
    {
        [Fact]
        public void TestEndToAssociation()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var assoc = factory.Association();
            var end = factory.AssociationEnd();
            end.Association = assoc;
            Assert.Equal(end, assoc.First);
            Assert.Equal(end, assoc.Second);
            Assert.Equal(assoc, end.Association);
            var imodel = model.ToImmutable();
            var iassoc = assoc.ToImmutable(imodel);
            var iend = end.ToImmutable(imodel);
            Assert.Equal(iend, iassoc.First);
            Assert.Equal(iend, iassoc.Second);
            Assert.Equal(iassoc, iend.Association);
        }

        [Fact]
        public void TestAssociationToEnd()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var assoc = factory.Association();
            var end1 = factory.AssociationEnd();
            var end2 = factory.AssociationEnd();
            assoc.First = end1;
            Assert.Equal(end1, assoc.First);
            Assert.Null(assoc.Second);
            Assert.Equal(assoc, end1.Association);
            Assert.Null(end2.Association);
            assoc.Second = end2;
            Assert.Equal(end1, assoc.First);
            Assert.Equal(end2, assoc.Second);
            Assert.Equal(assoc, end1.Association);
            Assert.Equal(assoc, end2.Association);
            var imodel = model.ToImmutable();
            var iassoc = assoc.ToImmutable(imodel);
            var iend1 = end1.ToImmutable(imodel);
            var iend2 = end2.ToImmutable(imodel);
            Assert.Equal(iend1, iassoc.First);
            Assert.Equal(iend2, iassoc.Second);
            Assert.Equal(iassoc, iend1.Association);
            Assert.Equal(iassoc, iend2.Association);
        }

        [Fact]
        public void TestEndToAssociationReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var assoc = factory.Association();
            var end = factory.AssociationEnd();
            end.Association = assoc;
            Assert.Equal(end, assoc.First);
            Assert.Equal(end, assoc.Second);
            Assert.Equal(assoc, end.Association);
            end.Association = null;
            Assert.Null(assoc.First);
            Assert.Null(assoc.Second);
            Assert.Null(end.Association);
            var imodel = model.ToImmutable();
            var iassoc = assoc.ToImmutable(imodel);
            var iend = end.ToImmutable(imodel);
            Assert.Null(iassoc.First);
            Assert.Null(iassoc.Second);
            Assert.Null(iend.Association);
        }

        [Fact]
        public void TestAssociationToEndReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var assoc = factory.Association();
            var end1 = factory.AssociationEnd();
            var end2 = factory.AssociationEnd();
            assoc.First = end1;
            Assert.Equal(end1, assoc.First);
            Assert.Null(assoc.Second);
            Assert.Equal(assoc, end1.Association);
            Assert.Null(end2.Association);
            assoc.Second = end2;
            Assert.Equal(end1, assoc.First);
            Assert.Equal(end2, assoc.Second);
            Assert.Equal(assoc, end1.Association);
            Assert.Equal(assoc, end2.Association);
            assoc.First = null;
            Assert.Null(assoc.First);
            Assert.Equal(end2, assoc.Second);
            Assert.Null(end1.Association);
            Assert.Equal(assoc, end2.Association);
            assoc.First = end1;
            assoc.Second = null;
            Assert.Equal(end1, assoc.First);
            Assert.Null(assoc.Second);
            Assert.Equal(assoc, end1.Association);
            Assert.Null(end2.Association);
            assoc.First = null;
            Assert.Null(assoc.First);
            Assert.Null(assoc.Second);
            Assert.Null(end1.Association);
            Assert.Null(end2.Association);
            var imodel = model.ToImmutable();
            var iassoc = assoc.ToImmutable(imodel);
            var iend1 = end1.ToImmutable(imodel);
            var iend2 = end2.ToImmutable(imodel);
            Assert.Null(iassoc.First);
            Assert.Null(iassoc.Second);
            Assert.Null(iend1.Association);
            Assert.Null(iend2.Association);
        }

        [Fact]
        public void TestEndToAssociationSet2Set()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var assoc = factory.Association();
            var end = factory.AssociationEndSet();
            end.Association = assoc;
            Assert.Contains(end, assoc.FirstSet);
            Assert.Contains(end, assoc.SecondSet);
            Assert.Equal(assoc, end.Association);
            var imodel = model.ToImmutable();
            var iassoc = assoc.ToImmutable(imodel);
            var iend = end.ToImmutable(imodel);
            Assert.Contains(iend, iassoc.FirstSet);
            Assert.Contains(iend, iassoc.SecondSet);
            Assert.Equal(iassoc, iend.Association);
        }

        [Fact]
        public void TestAssociationToEndSet2Set()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var assoc = factory.Association();
            var end1 = factory.AssociationEndSet();
            var end2 = factory.AssociationEndSet();
            assoc.FirstSet.Add(end1);
            Assert.True(assoc.FirstSet.Count == 1);
            Assert.True(assoc.SecondSet.Count == 0);
            Assert.Contains(end1, assoc.FirstSet);
            Assert.Equal(assoc, end1.Association);
            Assert.Null(end2.Association);
            assoc.SecondSet.Add(end2);
            Assert.True(assoc.FirstSet.Count == 1);
            Assert.True(assoc.SecondSet.Count == 1);
            Assert.Contains(end1, assoc.FirstSet);
            Assert.Contains(end2, assoc.SecondSet);
            Assert.Equal(assoc, end1.Association);
            Assert.Equal(assoc, end2.Association);
            var imodel = model.ToImmutable();
            var iassoc = assoc.ToImmutable(imodel);
            var iend1 = end1.ToImmutable(imodel);
            var iend2 = end2.ToImmutable(imodel);
            Assert.Contains(iend1, iassoc.FirstSet);
            Assert.Contains(iend2, iassoc.SecondSet);
            Assert.Equal(iassoc, iend1.Association);
            Assert.Equal(iassoc, iend2.Association);
        }

        [Fact]
        public void TestEndToAssociationResetSet2Set()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var assoc = factory.Association();
            var end = factory.AssociationEndSet();
            end.Association = assoc;
            Assert.True(assoc.FirstSet.Count == 1);
            Assert.True(assoc.SecondSet.Count == 1);
            Assert.Contains(end, assoc.FirstSet);
            Assert.Contains(end, assoc.SecondSet);
            Assert.Equal(assoc, end.Association);
            end.Association = null;
            Assert.True(assoc.FirstSet.Count == 0);
            Assert.True(assoc.SecondSet.Count == 0);
            Assert.Null(end.Association);
            var imodel = model.ToImmutable();
            var iassoc = assoc.ToImmutable(imodel);
            var iend = end.ToImmutable(imodel);
            Assert.Null(iassoc.First);
            Assert.Null(iassoc.Second);
            Assert.Null(iend.Association);
        }

        [Fact]
        public void TestAssociationToEndResetSet2Set()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var assoc = factory.Association();
            var end1 = factory.AssociationEndSet();
            var end2 = factory.AssociationEndSet();
            assoc.FirstSet.Add(end1);
            Assert.True(assoc.FirstSet.Count == 1);
            Assert.True(assoc.SecondSet.Count == 0);
            Assert.Contains(end1, assoc.FirstSet);
            Assert.Equal(assoc, end1.Association);
            Assert.Null(end2.Association);
            assoc.SecondSet.Add(end2);
            Assert.True(assoc.FirstSet.Count == 1);
            Assert.True(assoc.SecondSet.Count == 1);
            Assert.Contains(end1, assoc.FirstSet);
            Assert.Contains(end2, assoc.SecondSet);
            Assert.Equal(assoc, end1.Association);
            Assert.Equal(assoc, end2.Association);
            assoc.FirstSet.Remove(end1);
            Assert.True(assoc.FirstSet.Count == 0);
            Assert.True(assoc.SecondSet.Count == 1);
            Assert.Contains(end2, assoc.SecondSet);
            Assert.Null(end1.Association);
            Assert.Equal(assoc, end2.Association);
            assoc.FirstSet.Add(end1);
            assoc.SecondSet.Remove(end2);
            Assert.True(assoc.FirstSet.Count == 1);
            Assert.True(assoc.SecondSet.Count == 0);
            Assert.Contains(end1, assoc.FirstSet);
            Assert.Equal(assoc, end1.Association);
            Assert.Null(end2.Association);
            assoc.FirstSet.Remove(end1);
            Assert.True(assoc.FirstSet.Count == 0);
            Assert.True(assoc.SecondSet.Count == 0);
            Assert.Null(end1.Association);
            Assert.Null(end2.Association);
            var imodel = model.ToImmutable();
            var iassoc = assoc.ToImmutable(imodel);
            var iend1 = end1.ToImmutable(imodel);
            var iend2 = end2.ToImmutable(imodel);
            Assert.True(iassoc.FirstSet.Count == 0);
            Assert.True(iassoc.SecondSet.Count == 0);
            Assert.Null(iend1.Association);
            Assert.Null(iend2.Association);
        }

        [Fact]
        public void TestEndToAssociationList2List()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var assoc = factory.Association();
            var end = factory.AssociationEndList();
            end.Association = assoc;
            Assert.Contains(end, assoc.FirstList);
            Assert.Contains(end, assoc.SecondList);
            Assert.Equal(assoc, end.Association);
            var imodel = model.ToImmutable();
            var iassoc = assoc.ToImmutable(imodel);
            var iend = end.ToImmutable(imodel);
            Assert.Contains(iend, iassoc.FirstList);
            Assert.Contains(iend, iassoc.SecondList);
            Assert.Equal(iassoc, iend.Association);
        }

        [Fact]
        public void TestAssociationToEndList2List()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var assoc = factory.Association();
            var end1 = factory.AssociationEndList();
            var end2 = factory.AssociationEndList();
            assoc.FirstList.Add(end1);
            Assert.True(assoc.FirstList.Count == 1);
            Assert.True(assoc.SecondList.Count == 0);
            Assert.Contains(end1, assoc.FirstList);
            Assert.Equal(assoc, end1.Association);
            Assert.Null(end2.Association);
            assoc.SecondList.Add(end2);
            Assert.True(assoc.FirstList.Count == 1);
            Assert.True(assoc.SecondList.Count == 1);
            Assert.Contains(end1, assoc.FirstList);
            Assert.Contains(end2, assoc.SecondList);
            Assert.Equal(assoc, end1.Association);
            Assert.Equal(assoc, end2.Association);
            var imodel = model.ToImmutable();
            var iassoc = assoc.ToImmutable(imodel);
            var iend1 = end1.ToImmutable(imodel);
            var iend2 = end2.ToImmutable(imodel);
            Assert.Contains(iend1, iassoc.FirstList);
            Assert.Contains(iend2, iassoc.SecondList);
            Assert.Equal(iassoc, iend1.Association);
            Assert.Equal(iassoc, iend2.Association);
        }

        [Fact]
        public void TestEndToAssociationResetList2List()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var assoc = factory.Association();
            var end = factory.AssociationEndList();
            end.Association = assoc;
            Assert.True(assoc.FirstList.Count == 1);
            Assert.True(assoc.SecondList.Count == 1);
            Assert.Contains(end, assoc.FirstList);
            Assert.Contains(end, assoc.SecondList);
            Assert.Equal(assoc, end.Association);
            end.Association = null;
            Assert.True(assoc.FirstList.Count == 0);
            Assert.True(assoc.SecondList.Count == 0);
            Assert.Null(end.Association);
            var imodel = model.ToImmutable();
            var iassoc = assoc.ToImmutable(imodel);
            var iend = end.ToImmutable(imodel);
            Assert.Null(iassoc.First);
            Assert.Null(iassoc.Second);
            Assert.Null(iend.Association);
        }

        [Fact]
        public void TestAssociationToEndResetList2List()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var assoc = factory.Association();
            var end1 = factory.AssociationEndList();
            var end2 = factory.AssociationEndList();
            assoc.FirstList.Add(end1);
            Assert.True(assoc.FirstList.Count == 1);
            Assert.True(assoc.SecondList.Count == 0);
            Assert.Contains(end1, assoc.FirstList);
            Assert.Equal(assoc, end1.Association);
            Assert.Null(end2.Association);
            assoc.SecondList.Add(end2);
            Assert.True(assoc.FirstList.Count == 1);
            Assert.True(assoc.SecondList.Count == 1);
            Assert.Contains(end1, assoc.FirstList);
            Assert.Contains(end2, assoc.SecondList);
            Assert.Equal(assoc, end1.Association);
            Assert.Equal(assoc, end2.Association);
            assoc.FirstList.Remove(end1);
            Assert.True(assoc.FirstList.Count == 0);
            Assert.True(assoc.SecondList.Count == 1);
            Assert.Contains(end2, assoc.SecondList);
            Assert.Null(end1.Association);
            Assert.Equal(assoc, end2.Association);
            assoc.FirstList.Add(end1);
            assoc.SecondList.Remove(end2);
            Assert.True(assoc.FirstList.Count == 1);
            Assert.True(assoc.SecondList.Count == 0);
            Assert.Contains(end1, assoc.FirstList);
            Assert.Equal(assoc, end1.Association);
            Assert.Null(end2.Association);
            assoc.FirstList.Remove(end1);
            Assert.True(assoc.FirstList.Count == 0);
            Assert.True(assoc.SecondList.Count == 0);
            Assert.Null(end1.Association);
            Assert.Null(end2.Association);
            var imodel = model.ToImmutable();
            var iassoc = assoc.ToImmutable(imodel);
            var iend1 = end1.ToImmutable(imodel);
            var iend2 = end2.ToImmutable(imodel);
            Assert.True(iassoc.FirstList.Count == 0);
            Assert.True(iassoc.SecondList.Count == 0);
            Assert.Null(iend1.Association);
            Assert.Null(iend2.Association);
        }

        [Fact]
        public void TestEndToAssociationMultiSet2MultiSet()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var assoc = factory.Association();
            var end = factory.AssociationEndMultiSet();
            end.Association = assoc;
            Assert.Contains(end, assoc.FirstMultiSet);
            Assert.Contains(end, assoc.SecondMultiSet);
            Assert.Equal(assoc, end.Association);
            var imodel = model.ToImmutable();
            var iassoc = assoc.ToImmutable(imodel);
            var iend = end.ToImmutable(imodel);
            Assert.Contains(iend, iassoc.FirstMultiSet);
            Assert.Contains(iend, iassoc.SecondMultiSet);
            Assert.Equal(iassoc, iend.Association);
        }

        [Fact]
        public void TestAssociationToEndMultiSet2MultiSet()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var assoc = factory.Association();
            var end1 = factory.AssociationEndMultiSet();
            var end2 = factory.AssociationEndMultiSet();
            assoc.FirstMultiSet.Add(end1);
            Assert.True(assoc.FirstMultiSet.Count == 1);
            Assert.True(assoc.SecondMultiSet.Count == 0);
            Assert.Contains(end1, assoc.FirstMultiSet);
            Assert.Equal(assoc, end1.Association);
            Assert.Null(end2.Association);
            assoc.SecondMultiSet.Add(end2);
            Assert.True(assoc.FirstMultiSet.Count == 1);
            Assert.True(assoc.SecondMultiSet.Count == 1);
            Assert.Contains(end1, assoc.FirstMultiSet);
            Assert.Contains(end2, assoc.SecondMultiSet);
            Assert.Equal(assoc, end1.Association);
            Assert.Equal(assoc, end2.Association);
            var imodel = model.ToImmutable();
            var iassoc = assoc.ToImmutable(imodel);
            var iend1 = end1.ToImmutable(imodel);
            var iend2 = end2.ToImmutable(imodel);
            Assert.Contains(iend1, iassoc.FirstMultiSet);
            Assert.Contains(iend2, iassoc.SecondMultiSet);
            Assert.Equal(iassoc, iend1.Association);
            Assert.Equal(iassoc, iend2.Association);
        }

        [Fact]
        public void TestEndToAssociationResetMultiSet2MultiSet()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var assoc = factory.Association();
            var end = factory.AssociationEndMultiSet();
            end.Association = assoc;
            Assert.True(assoc.FirstMultiSet.Count == 1);
            Assert.True(assoc.SecondMultiSet.Count == 1);
            Assert.Contains(end, assoc.FirstMultiSet);
            Assert.Contains(end, assoc.SecondMultiSet);
            Assert.Equal(assoc, end.Association);
            end.Association = null;
            Assert.True(assoc.FirstMultiSet.Count == 0);
            Assert.True(assoc.SecondMultiSet.Count == 0);
            Assert.Null(end.Association);
            var imodel = model.ToImmutable();
            var iassoc = assoc.ToImmutable(imodel);
            var iend = end.ToImmutable(imodel);
            Assert.Null(iassoc.First);
            Assert.Null(iassoc.Second);
            Assert.Null(iend.Association);
        }

        [Fact]
        public void TestAssociationToEndResetMultiSet2MultiSet()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var assoc = factory.Association();
            var end1 = factory.AssociationEndMultiSet();
            var end2 = factory.AssociationEndMultiSet();
            assoc.FirstMultiSet.Add(end1);
            Assert.True(assoc.FirstMultiSet.Count == 1);
            Assert.True(assoc.SecondMultiSet.Count == 0);
            Assert.Contains(end1, assoc.FirstMultiSet);
            Assert.Equal(assoc, end1.Association);
            Assert.Null(end2.Association);
            assoc.SecondMultiSet.Add(end2);
            Assert.True(assoc.FirstMultiSet.Count == 1);
            Assert.True(assoc.SecondMultiSet.Count == 1);
            Assert.Contains(end1, assoc.FirstMultiSet);
            Assert.Contains(end2, assoc.SecondMultiSet);
            Assert.Equal(assoc, end1.Association);
            Assert.Equal(assoc, end2.Association);
            assoc.FirstMultiSet.Remove(end1);
            Assert.True(assoc.FirstMultiSet.Count == 0);
            Assert.True(assoc.SecondMultiSet.Count == 1);
            Assert.Contains(end2, assoc.SecondMultiSet);
            Assert.Null(end1.Association);
            Assert.Equal(assoc, end2.Association);
            assoc.FirstMultiSet.Add(end1);
            assoc.SecondMultiSet.Remove(end2);
            Assert.True(assoc.FirstMultiSet.Count == 1);
            Assert.True(assoc.SecondMultiSet.Count == 0);
            Assert.Contains(end1, assoc.FirstMultiSet);
            Assert.Equal(assoc, end1.Association);
            Assert.Null(end2.Association);
            assoc.FirstMultiSet.Remove(end1);
            Assert.True(assoc.FirstMultiSet.Count == 0);
            Assert.True(assoc.SecondMultiSet.Count == 0);
            Assert.Null(end1.Association);
            Assert.Null(end2.Association);
            var imodel = model.ToImmutable();
            var iassoc = assoc.ToImmutable(imodel);
            var iend1 = end1.ToImmutable(imodel);
            var iend2 = end2.ToImmutable(imodel);
            Assert.True(iassoc.FirstMultiSet.Count == 0);
            Assert.True(iassoc.SecondMultiSet.Count == 0);
            Assert.Null(iend1.Association);
            Assert.Null(iend2.Association);
        }

        [Fact]
        public void TestEndToAssociationMultiList2MultiList()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var assoc = factory.Association();
            var end = factory.AssociationEndMultiList();
            end.Association = assoc;
            Assert.Contains(end, assoc.FirstMultiList);
            Assert.Contains(end, assoc.SecondMultiList);
            Assert.Equal(assoc, end.Association);
            var imodel = model.ToImmutable();
            var iassoc = assoc.ToImmutable(imodel);
            var iend = end.ToImmutable(imodel);
            Assert.Contains(iend, iassoc.FirstMultiList);
            Assert.Contains(iend, iassoc.SecondMultiList);
            Assert.Equal(iassoc, iend.Association);
        }

        [Fact]
        public void TestAssociationToEndMultiList2MultiList()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var assoc = factory.Association();
            var end1 = factory.AssociationEndMultiList();
            var end2 = factory.AssociationEndMultiList();
            assoc.FirstMultiList.Add(end1);
            Assert.True(assoc.FirstMultiList.Count == 1);
            Assert.True(assoc.SecondMultiList.Count == 0);
            Assert.Contains(end1, assoc.FirstMultiList);
            Assert.Equal(assoc, end1.Association);
            Assert.Null(end2.Association);
            assoc.SecondMultiList.Add(end2);
            Assert.True(assoc.FirstMultiList.Count == 1);
            Assert.True(assoc.SecondMultiList.Count == 1);
            Assert.Contains(end1, assoc.FirstMultiList);
            Assert.Contains(end2, assoc.SecondMultiList);
            Assert.Equal(assoc, end1.Association);
            Assert.Equal(assoc, end2.Association);
            var imodel = model.ToImmutable();
            var iassoc = assoc.ToImmutable(imodel);
            var iend1 = end1.ToImmutable(imodel);
            var iend2 = end2.ToImmutable(imodel);
            Assert.Contains(iend1, iassoc.FirstMultiList);
            Assert.Contains(iend2, iassoc.SecondMultiList);
            Assert.Equal(iassoc, iend1.Association);
            Assert.Equal(iassoc, iend2.Association);
        }

        [Fact]
        public void TestEndToAssociationResetMultiList2MultiList()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var assoc = factory.Association();
            var end = factory.AssociationEndMultiList();
            end.Association = assoc;
            Assert.True(assoc.FirstMultiList.Count == 1);
            Assert.True(assoc.SecondMultiList.Count == 1);
            Assert.Contains(end, assoc.FirstMultiList);
            Assert.Contains(end, assoc.SecondMultiList);
            Assert.Equal(assoc, end.Association);
            end.Association = null;
            Assert.True(assoc.FirstMultiList.Count == 0);
            Assert.True(assoc.SecondMultiList.Count == 0);
            Assert.Null(end.Association);
            var imodel = model.ToImmutable();
            var iassoc = assoc.ToImmutable(imodel);
            var iend = end.ToImmutable(imodel);
            Assert.Null(iassoc.First);
            Assert.Null(iassoc.Second);
            Assert.Null(iend.Association);
        }

        [Fact]
        public void TestAssociationToEndResetMultiList2MultiList()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var assoc = factory.Association();
            var end1 = factory.AssociationEndMultiList();
            var end2 = factory.AssociationEndMultiList();
            assoc.FirstMultiList.Add(end1);
            Assert.True(assoc.FirstMultiList.Count == 1);
            Assert.True(assoc.SecondMultiList.Count == 0);
            Assert.Contains(end1, assoc.FirstMultiList);
            Assert.Equal(assoc, end1.Association);
            Assert.Null(end2.Association);
            assoc.SecondMultiList.Add(end2);
            Assert.True(assoc.FirstMultiList.Count == 1);
            Assert.True(assoc.SecondMultiList.Count == 1);
            Assert.Contains(end1, assoc.FirstMultiList);
            Assert.Contains(end2, assoc.SecondMultiList);
            Assert.Equal(assoc, end1.Association);
            Assert.Equal(assoc, end2.Association);
            assoc.FirstMultiList.Remove(end1);
            Assert.True(assoc.FirstMultiList.Count == 0);
            Assert.True(assoc.SecondMultiList.Count == 1);
            Assert.Contains(end2, assoc.SecondMultiList);
            Assert.Null(end1.Association);
            Assert.Equal(assoc, end2.Association);
            assoc.FirstMultiList.Add(end1);
            assoc.SecondMultiList.Remove(end2);
            Assert.True(assoc.FirstMultiList.Count == 1);
            Assert.True(assoc.SecondMultiList.Count == 0);
            Assert.Contains(end1, assoc.FirstMultiList);
            Assert.Equal(assoc, end1.Association);
            Assert.Null(end2.Association);
            assoc.FirstMultiList.Remove(end1);
            Assert.True(assoc.FirstMultiList.Count == 0);
            Assert.True(assoc.SecondMultiList.Count == 0);
            Assert.Null(end1.Association);
            Assert.Null(end2.Association);
            var imodel = model.ToImmutable();
            var iassoc = assoc.ToImmutable(imodel);
            var iend1 = end1.ToImmutable(imodel);
            var iend2 = end2.ToImmutable(imodel);
            Assert.True(iassoc.FirstMultiList.Count == 0);
            Assert.True(iassoc.SecondMultiList.Count == 0);
            Assert.Null(iend1.Association);
            Assert.Null(iend2.Association);
        }

    }
}
