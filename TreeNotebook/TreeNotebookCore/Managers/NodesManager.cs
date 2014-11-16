using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNotebookDataModel;

namespace TreeNotebookCore.Managers
{
    /// <summary>
    /// Retrieve Node entities from DB
    /// </summary>
    public class NodesManager
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public List<Node> GetAll(TreeNotebookEntities context)
        {
            return context.Nodes.ToList();
        }

        /// <summary>
        /// Gets the by unique identifier.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="nodeID">The node unique identifier.</param>
        /// <returns>the found node</returns>
        public Node GetById(TreeNotebookEntities context, int nodeID)
        {
            return context.Nodes.Where(p => p.NodeId.Equals(nodeID)).FirstOrDefault();
        }

        /// <summary>
        /// Gets all child nodes by main node unique identifier.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="nodeID">The node unique identifier.</param>
        /// <returns></returns>
        public List<Node> GetAllChildNodesByMainNodeId(TreeNotebookEntities context, int nodeID)
        {
            return context.Nodes.Where(p => p.ParentNodeId.Equals(nodeID)).ToList();
        }


        /// <summary>
        /// Adds the new.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="nodeXml">The node XML.</param>
        /// <param name="parentNodeId">The parent node unique identifier.</param>
        public void AddNew(TreeNotebookEntities context, string nodeXml = "", int? parentNodeId = null)
        {
            Node newNode = new Node()
            {
                NodeXml = nodeXml,
                CreationDateTime = DateTime.Now,
                ParentNodeId = parentNodeId
            };

            context.Nodes.Add(newNode);
            context.SaveChanges();
        }

        public void Update(TreeNotebookEntities context, string nodeXml = "", int? parentNodeId = null)
        {
            Node newNode = new Node()
            {
                NodeXml = nodeXml,
                CreationDateTime = DateTime.Now,
                ParentNodeId = parentNodeId
            };

            context.Nodes.Add(newNode);
            context.SaveChanges();
        }


        /// <summary>
        /// Removes the node by unique identifier.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="nodeId">The node unique identifier.</param>
        public void RemoveNodeById(TreeNotebookEntities context, int nodeId)
        {
            Node nodeForRemove = GetById(context, nodeId);
            List<Node> childNodes = GetAllChildNodesByMainNodeId(context, nodeForRemove.NodeId);
            foreach (var currentChild in childNodes)
            {
                this.RemoveNodeById(context, currentChild.NodeId);
            }
            context.Nodes.Remove(nodeForRemove);
           
            context.SaveChanges();
        }
    }
}
